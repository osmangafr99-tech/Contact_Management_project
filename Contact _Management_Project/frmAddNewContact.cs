using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1
{
    public partial class frmAddNewContact : Form
    {
        private int _ID = -1; private string _imagePath = ""; private int CountryID=-1;
        public frmAddNewContact()
        {
            InitializeComponent();
        }


        //////////////////////////////////////////////////////////////////////////////
        /// methods
        private bool ValidateEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                return false;
            }
            return true;
        }
        private bool ValidateDateOfBirth()
        {
            if (!dtpDateOfBirth.Checked)
            {
                MessageBox.Show("يرجى اختيار تاريخ الميلاد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpDateOfBirth.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("تاريخ الميلاد لا يمكن أن يكون في المستقبل!", "خطأ في التاريخ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int age = DateTime.Now.Year - dtpDateOfBirth.Value.Year;
            if (age > 60)
            {
                MessageBox.Show("يرجى إدخال تاريخ ميلاد صحيح (العمر غير منطقي).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool ValidatePhone()
        {
            string phone = txtPhone.Text.Trim();
            if (phone.Length != 11)
            {
                MessageBox.Show("يجب أن يكون رقم الهاتف مكوناً من 11 رقماً .", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Choose_apicture()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "اختر صورة الاتصال";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _imagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(_imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                _imagePath = "";
            }
        }
        private void Removeimage()
        {
            pictureBox1.Image = null;
            _imagePath = "";
        }
        private bool Is_Null()
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text)|| string.IsNullOrEmpty(txtPhone.Text) ||  string.IsNullOrEmpty(txtAddress.Text)|| !dtpDateOfBirth.Checked || cbCountry.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء ملئ الحقول", "خطأ القييم فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Fill_ComboBox()
        {
            DataTable dtCountries = ClsCountries.GetAllCountry(); // مثال لدالة جلب البيانات
            if (dtCountries != null)
            {
                foreach (DataRow row in dtCountries.Rows)
                {
                    cbCountry.Items.Add(row["CountryName"]);
                }
            }
            cbCountry.SelectedIndex = 0;
        }


        //////////////////////////////////////////////////////////////////////////////

        /// Validation :
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
            if (txtFirstName.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "First Name should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtLastName.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Last Name should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Email should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
            if (!ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("البريد الإلكتروني غير صالح. تأكد من وجود '@' ونقطة '.' مثل example@domain.com", "خطأ في الصيغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                txtEmail.Focus();
            }
            else
            {
                e.Cancel = false;
            }
            //////////////////////////////////////////////////////////////////////////////
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Phone  should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }
            if (!ValidatePhone())
            {
                e.Cancel = true;
                txtPhone.Focus();
            }
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtPhone.Text.Length >= 11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dtpDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateDateOfBirth())
            {
                e.Cancel = true;
                txtPhone.Focus();
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAddress.Text.Length >= 200 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Address  should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        /// events :
        private void btn_Remove_Image_Click(object sender, EventArgs e)
        {
            Removeimage();
        }
        private void btn_SetImage_Click(object sender, EventArgs e)
        {
            Choose_apicture();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Is_Null())
            {
                return;
            }
            Fill_data();
        }
        private void frmAddNewContact_Load(object sender, EventArgs e)
        {
            Fill_ComboBox();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //////////////////////////////////////////////////////////////////////////////

        /// Filling DAta :

        private void Fill_data()
        {
            clsContact _Contact = new clsContact();
            CountryID = ClsCountries.FindCountryByName(cbCountry.Text).CountryID;

            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.DateOfBirth = dtpDateOfBirth.Value;
            _Contact.CountryID = CountryID;

            if (_imagePath != null)
            {
                _Contact.ImagePath = _imagePath;
                //pictureBox1.Image = Image.FromFile(@"C:\Rome Of Solution\New folder (2)\Images\myImage.png");
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
                _Contact.ImagePath = "";

            if (_Contact.action_done())
            { 
                MessageBox.Show("Data Saved Successfully." + _Contact.ID);
                lblContactID.Text = _Contact.ID.ToString();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");
        }

        //////////////////////////////////////////////////////////////////////////////

    }
}