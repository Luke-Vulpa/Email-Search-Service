using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSearchSerice
{
    //First Entry issues seems to be wrong term is adding an incorrect email first
    public partial class EmailFinder : Form
    {
        private string currentLine;
        private string aFilePath;
        private string searchTerm;
        delegate void SetTextCallback();

        private bool searchCompleted;
        private bool searchPaused;
        private bool searchStopped;

        StreamReader aReader;
        StreamWriter aWriter;

        Thread thread;

        List<string> emailList;

        public EmailFinder()
        {
            emailList = new List<string>();

            InitializeComponent();
            initialiseGui();

            searchPaused = false;
            searchStopped = false;
            searchButton.Enabled = false;
        }

        #region Dialogs
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            
        }
        #endregion

        #region Button Click Events

        private void searchButton_Click(object sender, EventArgs e)
        {
            startSearchState();
            //sets application state
            if (searchTerm == "")
            {
                searchButton.Enabled = false;
                MessageBox.Show("Please enter a search term", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                searchTerm = searchTextBox.Text;
                if (backgroundWorker1.IsBusy != true)
                {

                    backgroundWorker1.RunWorkerAsync();
                }

            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            pauseToggle();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        exportAsTxt();
                        break;
                    case 2:
                        exportAsCvs();
                        break;
                    case 3:
                        exportAsHtml();
                        break;
                }
            }
            //foreach value in list add to file then close and clearlist
            Refresh();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.searchStopped = true;
            // Cancel the asynchronous operations. 
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            resetSearchControls();

        }

        #endregion

        #region Other Events

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                aFilePath = openFileDialog1.FileName;
            }
            //searchTerm = searchTextBox.Text;
        }

        private void resultTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                resultTextBox.SelectAll();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            searchTerm = searchTextBox.Text;
            if (searchTextBox.Text != "")
            {
                searchButton.Enabled = true;
            }
            else
            {
                searchButton.Enabled = false;
            }
        }

        private void EmailFinder_Load(object sender, EventArgs e)
        {
            aReader.Close();
        }

        #endregion

        #region Gui States

        private void startSearchState()
        {
            //searchTerm = searchTextBox.Text;
            emailList = new List<string>();
            
            pauseButton.Visible = true;
            pauseButton.Text = "Pause";
            pauseButton.Enabled = true;

            searchPaused = false;
            searchStopped = false;
            searchButton.Enabled = false;
            searchTextBox.Enabled = false;

            stopButton.Visible = true;
            stopButton.Enabled = true;

            resultTextBox.Clear();

            resultLabel.Text = "Results: " + emailList.Count;
        }

        void resetSearchControls()
        {
            //search clicked
            // change button and textbox state

            //searchTerm = searchTextBox.Text;
            pauseButton.Visible = false;
            pauseButton.Text = "Pause";
            
            searchTextBox.Enabled = true;
            searchButton.Enabled = false;

            stopButton.Visible = false;
            saveButton.Visible = false;

            if(emailList.Count >= 1)
            {
                resultTextBox.Enabled = true;
            }
            else
            {

                resultTextBox.Enabled = false;
                
            }

            if (searchStopped || searchCompleted)
            {
                searchButton.Enabled = false;
                
                stopButton.Visible = false;
                searchTextBox.Clear();
                saveButton.Visible = true;
                this.searchPaused = false;

                saveFileDialog1.FileName = searchTerm;
            }


            this.Refresh();

        }

        private void initialiseGui()
        {
            openFileDialog1.Filter = "Text File|*.txt|Cvs File|*.cvs|Html File|*.html";
            saveFileDialog1.Filter = "Text File|*.txt|Cvs File|*.cvs|Html File|*.html";

            searchTerm = "";
            searchTextBox.Text = searchTerm;
            searchButton.Enabled = false;

            resultLabel.Text = "Results: " + emailList.Count;
            resultTextBox.Enabled = false;

            saveButton.Visible = false;
            pauseButton.Visible = false;
            stopButton.Visible = false;
        }

        #endregion
        
        private void pauseToggle()
        {
            searchPaused = !searchPaused;

            if (searchPaused)
            {
                pauseButton.Text = "Resume";
            }
            else
            {
                pauseButton.Text = "Pause";
            }
        }

        #region BackgroundWorker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            thread = new Thread(new ThreadStart(proc));
 

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                try
                {
                    aReader = new StreamReader(aFilePath);
                    
                    while (!aReader.EndOfStream || aReader != null)
                    {
                        if (searchPaused != true && searchStopped != true)
                        {                            
                            currentLine = aReader.ReadLine();

                            if (currentLine.EndsWith(searchTerm, StringComparison.CurrentCulture))
                            {
                                proc();
                            }
                        }
                        if (searchStopped)
                        {
                            backgroundWorker1.CancelAsync();
                        }
                    }
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Invalid file or file not selected", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("End of file reached", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    searchCompleted = true;
                    
                }
                finally
                {
                    backgroundWorker1.CancelAsync();
                }
            }
        }

        private void proc()
        {
            
            if (resultTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(proc);
                this.Invoke(d, new object[] { });
                resultTextBox.Enabled = true;
            }
            else
            {
                resultLabel.Text = "Results: " + emailList.Count;
                resultTextBox.Enabled = true;
                resultTextBox.AppendText(this.currentLine + Environment.NewLine);
                emailList.Add(currentLine);
                
            }
        }

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progressBar1.Value = e.ProgressPercentage;

        //}

        //when backgroundWork has finish- or error - cancelled
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resetSearchControls();
            searchTextBox.Clear();
        }


        #endregion

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if(searchTextBox.Text != "")
            {
                searchButton.Enabled = true;
            }
            else
            {
                searchButton.Enabled = false;
            }
        }

        private void resultTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void exportAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            exportButton_Click(sender,e);

        }

        void exportAsCvs()
        {
           
            aWriter = new StreamWriter(saveFileDialog1.FileName);

            foreach(string element in emailList)
            {
                aWriter.WriteLine(element + "," );

            }

            aWriter.Close();
        
        }

        void exportAsTxt()
        {
            aWriter = new StreamWriter(saveFileDialog1.FileName);

            foreach (string element in emailList)
            {
                aWriter.WriteLine(element);
            }

            aWriter.Close();
        
        }

        void exportAsHtml()
        {
            aWriter = new StreamWriter(saveFileDialog1.FileName);

            aWriter.WriteLine("<!DOCTYPE html><html><head>");
            aWriter.WriteLine("<title>Title of the document</title></head>");
            aWriter.WriteLine("<style> </style>");
            aWriter.WriteLine("<body><table style=\"width:100%\"/><tr><td>Search results for" + searchTerm + "</td>");
            
            foreach (string element in emailList)
            {
                aWriter.WriteLine("<td>" + element + "</td>");

            }
            aWriter.WriteLine("</tr></table></body></html>");

            aWriter.Close();
        }


    }
}
