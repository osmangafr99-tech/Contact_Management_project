using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmDeleteContact : Form
    {
        bool Confirmdeletion = false; private int _contactID; bool Deletedsuccessfully=false; bool contactnotexist = false;
        public frmDeleteContact( int contactID)
        {
            InitializeComponent();
            _contactID = contactID;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////
        /// /// methods
        private void _RefreshContactsList()
        {
            if (Deletedsuccessfully==false)
            {
                dgvSingleResult.DataSource = clsContact.Find(_contactID);

                clsContact contact = clsContact.Find(_contactID);
                if (contact != null)
                {
                    dgvSingleResult.DataSource = new List<clsContact> { contact }; 
                }

                if (dgvSingleResult.DataSource==null)
                {
                  contactnotexist=true;
                }
                else
                {
                    contactnotexist=false;
                }
            }
            else
            {
                dgvSingleResult.DataSource = null;
            }
           
        }
        private void delete_contact(int contact_ID,bool delete)
        {
            if (delete)
            {
                if (clsContact._Delete_ContactByid(contact_ID))
                {
                    MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information); Deletedsuccessfully = true;
                    _RefreshContactsList();
                }
                else
                {
                    MessageBox.Show("Deletion failed.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                if(MessageBox.Show("Do you want to lock the delete screen?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        }
        ////////////////////////////////////////////////////////////////////////////////////////////
        /// /// events :
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (contactnotexist == true)
            {
                MessageBox.Show("The contact does not exist.", "Important Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); Deletedsuccessfully = true;
                return;
            }
            if (MessageBox.Show("Are you sure?.", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                delete_contact(_contactID, Confirmdeletion = true);
            }
            else
            {
                delete_contact(_contactID, Confirmdeletion = false);
            }
          
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDeleteContact_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }
    }
}
