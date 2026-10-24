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

namespace WindowsFormsApp1
{
    public partial class frminformationcard : Form
    {
        private int _contactID;
        public frminformationcard(int contactID)
        {
            InitializeComponent();
            _contactID = contactID;
        }
        private void informationcard_Load(object sender, EventArgs e)
        {
            clsContact contact = clsContact.Find(_contactID);

            if (contact != null)
            {
                lablContactID.Text = contact.ID.ToString();
                lblFirstName.Text = contact.FirstName; label23.Text = contact.FirstName;
                lblLastName.Text = contact.LastName;
                lblEmail.Text = contact.Email;
                lblPhone.Text = contact.Phone;
                lblAddress.Text = contact.Address;
                lblDateOfBirth.Text = contact.DateOfBirth.ToShortDateString();
                lblCountryID.Text = contact.CountryID.ToString();
                if (contact.ImagePath != null)
                {
                    lblImagePath.Text = contact.ImagePath;
                    //pictureBox1.Image = Image.FromFile(@"C:\Rome Of Solution\New folder(2)\1");
                    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    lblImagePath.Text = "Empty";
                }
            }
        }
    }

    }
