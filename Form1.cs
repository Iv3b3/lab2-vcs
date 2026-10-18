using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            var validators = new List<IValidator>
            {
                new EmailValidator(),
                new PhoneValidator(),
                new PasswordValidator(),
                new AgeValidator()
            };

 
            var validationService = new ValidationService(validators);


            var userData = new UserData
            {
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text,
                Age = int.TryParse(txtAge.Text, out int age) ? age : 0
            };

            lstErrors.Items.Clear(); 

            if (validationService.ValidateAll(userData, out List<string> errors))
            {
                MessageBox.Show("Все данные корректны! Валидация пройдена.",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var error in errors)
                {
                    lstErrors.Items.Add(error);
                }
            }
        }
    }
}
