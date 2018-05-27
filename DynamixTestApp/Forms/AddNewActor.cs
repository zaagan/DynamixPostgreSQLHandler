using System;
using System.Windows.Forms;

namespace DynamixTestApp.Forms
{
    public partial class AddNewActor : Form
    {
        Action<string, string> addNewActor = null;
        public AddNewActor(Action<string,string> addNewActor)
        {
            InitializeComponent();
            this.addNewActor = addNewActor;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            string f_name = tbxFirstName.Text.Trim();
            string l_name = tbxLastName.Text.Trim();
            if (string.IsNullOrEmpty(f_name) || string.IsNullOrEmpty(l_name))
            {
                MessageBox.Show("First Name and Last Name are required");
            }
            else {
                addNewActor(f_name, l_name);
                this.Close();
            }
        }
    }
}
