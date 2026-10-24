using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class frmListContacts1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////

        /// Variables :

        private sbyte Count_NumberOfSearches = 0; private bool isLoaded = false; private bool isLoaded_ShortDetails = false; private bool isLoaded_searchContacts = false;private int _selectedID =-1;

        ////////////////////////////////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////////////////////////////////

        ///constructor :
        public frmListContacts1()
        {
            InitializeComponent();
        }
        ////////////////////////////////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////////////////////////////////

        ///methods:
        private void _Themes_DataGridView()
        {
            if (!isLoaded)
            {
                dgvAllContacts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 30, 54);
                dgvAllContacts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvAllContacts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                isLoaded = true;
            }
        }
        private void _Visible_lblContacts_ShortDetails()
        {
            if (!isLoaded_ShortDetails)
            {
                lblContactID.Visible = true; lblFirstName.Visible = true; lblLastName.Visible = true;
                lblEmail.Visible = true; lblPhone.Visible = true; lblAddress.Visible = true; lblcontent.Visible = true;
                lblDateOfBirth.Visible = true; lblCountryID.Visible = true; lblImagePath.Visible = true;isLoaded_ShortDetails = true;
            }
        }
        private void _Visible_lblContacts_searchContacts()
        {
            if (!isLoaded_searchContacts)
            {
                label32.Visible = true; label31.Visible = true; label30.Visible = true; label25.Visible = true;isLoaded_searchContacts = true;
            }
        }
        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }
        private void _searchContacts()
        {
            int searchID; Count_NumberOfSearches++; progressBar1.Value = 0;
            label32.Text = Count_NumberOfSearches.ToString();
            if (int.TryParse(txtSearch.Text, out searchID))
            {
                clsContact contact = clsContact.Find(searchID);
                if (contact != null)
                {
                    dgvSingleResult.DataSource = new List<clsContact> { contact }; label31.Text = "A successful search operation"; label30.Text = "Yes"; label25.Text = "NO";
                }
                else
                {
                    label31.Text = "Unsuccessful search operation"; label30.Text = "NO"; label25.Text = "Yes"; progressBar1.BackColor = Color.Red; dgvSingleResult.DataSource = null;
                }
            }
            ////////////////////////////////////////////////////
            _Visible_lblContacts_searchContacts();
            ////////////////////////////////////////////////////
            for (int i = 0; i < 4; i++)
            {
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value += 25;
                }
            }
        }
        private void _ShortDetails (object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAllContacts.Rows[e.RowIndex];
                pictureBox3.Image = Properties.Resources._44; pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                lblcontent.Text= row.Cells["FirstName"].Value.ToString();
                lblContactID.Text = row.Cells["ContactID"].Value.ToString();
                _selectedID=Convert.ToInt32(lblContactID.Text);
                lblFirstName.Text = row.Cells["FirstName"].Value.ToString();
                lblLastName.Text = row.Cells["LastName"].Value.ToString();
                lblEmail.Text = row.Cells["Email"].Value.ToString();
                lblPhone.Text = row.Cells["Phone"].Value.ToString();
                lblAddress.Text = row.Cells["Address"].Value.ToString();
                lblDateOfBirth.Text = row.Cells["DateOfBirth"].Value.ToString();
                lblCountryID.Text = row.Cells["CountryID"].Value.ToString();
                lblImagePath.Text = row.Cells["ImagePath"].Value.ToString();
                _Visible_lblContacts_ShortDetails();
            }

        }
        private void DeleteFrom_Contixt_menuStrip1()
        {
            if (_selectedID == -1)
            {
                MessageBox.Show("Please select a contact.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                if (clsContact.isContactExist(_selectedID))
                {
                    if (clsContact._Delete_ContactByid(_selectedID))
                    {
                        MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshContactsList();
                    }
                    else
                    {
                        MessageBox.Show("Deletion failed.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("The contact does not exist.", "Important Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void DeleteFrm()
        {
            if (_selectedID == -1)
            {
                MessageBox.Show("Please select a contact.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmDeleteContact frmDeleteContact = new frmDeleteContact(_selectedID);
                frmDeleteContact.ShowDialog();
            }
            _RefreshContactsList();
        }
        private void InformationCard()
        {
            if (_selectedID == -1)
            {
                MessageBox.Show("Please select a contact.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frminformationcard frminformationcard = new frminformationcard(_selectedID);
                frminformationcard.ShowDialog();
            }
        }
        private void Edit()
        {
            if (_selectedID == -1)
            {
                MessageBox.Show("Please select a contact.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmEditContact frmEditContact  = new frmEditContact(_selectedID);
                frmEditContact.ShowDialog();
            }
        }

        private void AddNewcontact()
        {
            frmAddNewContact frmAddNewContact = new frmAddNewContact();
            frmAddNewContact.ShowDialog();
        }

        ////////////////////////////////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////////////////////////////////

        /// events :
        private void frmListContacts_Load(object sender, EventArgs e)
        {
            _RefreshContactsList(); _Themes_DataGridView();
        }
        private void dgvAllContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _ShortDetails(sender, e);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchContacts();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tsmshowInformationCard_Click(object sender, EventArgs e)
        {
            InformationCard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewcontact();
            _RefreshContactsList();
        }

        private void tsmaddNew_Click(object sender, EventArgs e)
        {
            AddNewcontact();
            _RefreshContactsList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteFrm();
            _RefreshContactsList();
        }

        private void tsmdelete_Click(object sender, EventArgs e)
        {
            DeleteFrom_Contixt_menuStrip1();
            _RefreshContactsList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            _RefreshContactsList();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            Edit();
            _RefreshContactsList();
        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frminformationcard frminformationcard = new frminformationcard(22);
            frminformationcard.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        ////////////////////////////////////////////////////////////////////////////////////////
    }
}
