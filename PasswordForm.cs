using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string Exitcode = System.Configuration.ConfigurationManager.AppSettings["Exitcode"]; 

            if (txt_Password.Text == Exitcode)
            {
                // The password is ok.
                txt_Password.Clear();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // The password is invalid.
                txt_Password.Clear();
                MessageBox.Show("Invalid password.");
                txt_Password.Focus();
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
