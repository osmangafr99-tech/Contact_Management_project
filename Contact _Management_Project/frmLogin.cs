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

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        int countNumberofattempts = 0; string email = "osmangafr99@gmail.com"; string Password = "01150679370";
        public frmLogin()
        {
            InitializeComponent();
        }
        //////////////////////////////////////////////////////////////////////////////

        /// Validation :
        private bool ValidateEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                return false;
            }
            return true;
        }
        private void txtEnter_Email_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEnter_Email.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtEnter_Email.Text))
            {
                errorProvider1.SetError(txtEnter_Email, "Email should have a value!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEnter_Email, "");
            }
            if (!ValidateEmail(txtEnter_Email.Text))
            {
                MessageBox.Show("البريد الإلكتروني غير صالح. تأكد من وجود '@' ونقطة '.' مثل example@domain.com", "خطأ في الصيغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtEnter_Password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnter_Password.Text))
            {
                errorProvider1.SetError(txtEnter_Password, "Password should have a value!");
            }
            else
            {
                errorProvider1.SetError(txtEnter_Password, "");
            }
        }
        private void txtEnter_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtEnter_Password.Text.Length >= 11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        void asd()
        {
            if (txtEnter_Email.Text == "" || txtEnter_Password.Text == "")
            {
                MessageBox.Show("should have a value..", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); lblCount.Text = Convert.ToString(countNumberofattempts);
                return;
            }
            if (txtEnter_Email.Text==email && txtEnter_Password.Text == Password)
            {
                this.Hide();
                frmListContacts1 mainForm = new frmListContacts1();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();

            }
            if (txtEnter_Email.Text != email)
            {
                countNumberofattempts++;
                MessageBox.Show("The email is incorrect..", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); lblCount.Text = Convert.ToString( countNumberofattempts);
            }
            if (txtEnter_Password.Text != Password)
            {
                countNumberofattempts++;
                MessageBox.Show("The Passowrd is incorrect..", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); lblCount.Text = Convert.ToString(countNumberofattempts);
            }
            if (countNumberofattempts==3)
            {
                MessageBox.Show("You have exceeded the maximum number of attempts.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            asd();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
