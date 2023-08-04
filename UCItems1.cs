using System;
using System.IO;

using System.Data.SqlClient;

namespace project_TelegraphicTransfer
{
    public partial class UCItems1 : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-8S284IC;Initial Catalog=db_TTProject;User ID=sa;Password=BSvu6ZDj;";

        // Method to delete the file represented by this control.

        int fileId;
        public void DeleteFile()
        {
            // Ensure that the FileId property is properly set in this user control.
            int fileId = FileId;

            // Check if FileId is valid (greater than 0).
            if (fileId > 0)
            {
                try
                {
                    using (SqlConnection connsql = new SqlConnection(connectionString))
                    {
                        connsql.Open();

                        // Prepare the SQL query to delete the file from the "tbl_FILE" table.
                        string deleteQuery = "DELETE FROM tbl_FILE WHERE ID = @fileId";

                        // Create the SqlCommand object and pass the query and connection.
                        using (SqlCommand command = new SqlCommand(deleteQuery, connsql))
                        {
                            // Add the parameter for the fileId to the SqlCommand.
                            command.Parameters.AddWithValue("@fileId", fileId);

                            // Execute the delete query.
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check the rows affected to see if the file was deleted successfully.
                            if (rowsAffected > 0)
                            {
                                // File deleted successfully.
                                // You can show a message to the user or perform any other actions as needed.
                            }
                            else
                            {
                                // File with the given ID not found or not deleted.
                                // You can show a message to the user or perform any other actions as needed.
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the file: " + ex.Message);
                }
            }
        }

        private void btn_deleteTTs_Click(object sender, EventArgs e)
        {

            // Assuming you have a reference to the selected UCItems1 control.
            UCItems1 selectedUCItem = GetSelectedUCItem();

            if (selectedUCItem != null)
            {
                // Call the DeleteFile method on the selected UCItems1 control.
                selectedUCItem.DeleteFile();
            }
            else
            {
                // No file selected. You can show an error message or perform any other actions as needed.
            }
        }

        // Helper method to get the selected UCItems1 control.
        private UCItems1 GetSelectedUCItem()
        {
            // Replace flp_fileItemsShowingPanel with the actual name of the panel containing UCItems1 controls.
            //foreach (UCItems1 ucItem in flp_fileItemsShowingPanel.Controls.OfType<UCItems1>())
            {
                // Assuming you have a property IsSelected in the UCItems1 user control to indicate if it's selected.
               // if (ucItem.IsSelected)
                {
                   // return ucItem;
                }
            }

            return null;
        }


        public UCItems1()
        {
            InitializeComponent();
        }

        #region Properties
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private int _fileId;
        public int FileId
        {
            get { return _fileId; }
            set { _fileId = value; }
        }



        #endregion

        private void UCItems1_Load(object sender, EventArgs e)
        {
            lblFileNameShowing.Text = FileName;
        }


        private void btn_editTTs_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if FormMAIN is already open
                FormMAIN formMain = Application.OpenForms.OfType<FormMAIN>().FirstOrDefault();

                if (formMain != null)
                {
                    formMain.LblTest = FileName; //to display file name

                    // FormMAIN is open, check for UCFileHandeling user control
                    UCFileHandeling FileHandelingUserControl = formMain.FileHandelingUserControl;

                    if (FileHandelingUserControl != null)
                    {
                        UCTTsHandeling uCTTsHandeling = FileHandelingUserControl.UserControlTTShow as UCTTsHandeling;

                        if (uCTTsHandeling != null && !uCTTsHandeling.IsDisposed)
                        {
                            uCTTsHandeling.Dispose();
                        }

                        uCTTsHandeling = new UCTTsHandeling();
                        uCTTsHandeling.FileName = FileName;
                        uCTTsHandeling.FileId = FileId;
                        uCTTsHandeling.Show();
                        uCTTsHandeling.Dock = DockStyle.Fill;

                        FileHandelingUserControl.UserControlTTShow = uCTTsHandeling;

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        
    }
}

           
        
    

