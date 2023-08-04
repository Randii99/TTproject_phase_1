
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;


namespace project_TelegraphicTransfer
{
    public partial class UCFileHandeling : UserControl
    {
        #region connection
        SqlConnection connsql = new SqlConnection(connectionString.ConnectionString);
        #endregion

        #region properties
        private string _lblTest;
        public string LblTest
        {
            get { return _lblTest; }
            set
            {
                _lblTest = value;
                lblTest.Text = value;
            }
        }

        private UserControl _userControlTTShow;
        public UserControl UserControlTTShow
        {
            get { return _userControlTTShow; }
            set
            {
                _userControlTTShow = value;
                splitContainerTTHandleing.Panel1.Controls.Add(value);
            }
        }


        private UserControl _userControlFormShow;
        public UserControl UserControlFormShow
        {
            get { return _userControlFormShow; }
            set
            {
                _userControlFormShow = value;
                splitContainerTTHandleing.Panel2.Controls.Add(value);
            }
        }

        private int _fileId;
        public int FileId
        {
            get { return _fileId; }
            set { _fileId = value; }
        }

        #endregion

        public UCFileHandeling()
        {
            InitializeComponent();
            //lblTest.Text = _lblTest;

        }



        //++++++++++++++++++++++++++++++++ have to implement    
        public void loadItems()
        {
            try
            {
                flp_fileItemsShowingPanel.Controls.Clear();
                connsql.Open();

                // Get the search text from tb_search
                string searchText = tb_search.Text.Trim();

                // Create a SqlCommand to retrieve the rows based on the search text (if provided)
                SqlCommand cmdItemLoad;

                if (!string.IsNullOrEmpty(searchText))
                {
                    // Use LIKE operator to filter based on FileName
                    cmdItemLoad = new SqlCommand("SELECT TOP 10 * FROM tbl_FILE WHERE Name LIKE '%' + @searchText + '%' ORDER BY DATE_TIME DESC", connsql);
                    cmdItemLoad.Parameters.AddWithValue("@searchText", searchText);
                }
                else
                {
                    // If search text is empty, load all items
                    cmdItemLoad = new SqlCommand("SELECT TOP 10 * FROM tbl_FILE ORDER BY DATE_TIME DESC", connsql);
                }

                // Execute the query and retrieve the rows
                SqlDataReader reader = cmdItemLoad.ExecuteReader();

                while (reader.Read())
                {
                    UCItems1 uCItem = new UCItems1();
                    uCItem.FileName = reader["Name"].ToString();
                    uCItem.FileId = int.Parse(reader["ID"].ToString());

                    // Add UCItems1 control to the panel
                    flp_fileItemsShowingPanel.Controls.Add(uCItem);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connsql.Close();
            }
        }




        // search the file
        private void btn_search_Click(object sender, EventArgs e)
        {
            loadItems();
        }

        private void btn_loadAll_Click(object sender, EventArgs e)
        {
            tb_search.Text = ""; // Clear the search text
            loadItems(); // Call loadItems without any search text to load all items
        }


        private void UCFileHandeling_Load(object sender, EventArgs e)
        {
            loadItems();

        }

        private void btn_CreateNEwTTs_Click(object sender, EventArgs e)
        {

            

            try
            {
                //find user
                FormMAIN formMain = Application.OpenForms.OfType<FormMAIN>().FirstOrDefault();

                if (formMain != null)
                {
                    // Create a new instance of FormMain
                    FormAddNewFile newFormAddNewFile = new FormAddNewFile();
                    newFormAddNewFile.CreatorID = formMain.UserID;

                    // Disable all other forms
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form != newFormAddNewFile)
                        {
                            form.Enabled = false;
                        }
                    }

                    // Show the new FormMain
                    newFormAddNewFile.ShowDialog();



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //after form closed
                loadItems();
            }

        }

      

        
    }
}
