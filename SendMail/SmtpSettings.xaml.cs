using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMail
{
    /// <summary>
    /// Interaction logic for SmtpSettings.xaml
    /// </summary>
    public partial class SmtpSettings : Window
    {
        public SmtpSettings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            SmtpServer smtpServer = new SmtpServer();

            if (txtEmailAddress.Text != null && txtEmailAddress.Text.Length < 50) smtpServer.EmailAddress = txtEmailAddress.Text;
            else check = false;

            if (txtSmtpServer.Text != null && txtSmtpServer.Text.Length < 50) smtpServer.EmailSmtpServer = txtSmtpServer.Text;
            else check = false;

            if (txtSmtpPort.Text != null && Convert.ToInt32(txtSmtpPort.Text) > 0) smtpServer.EmailSmtpPort = Convert.ToInt32(txtSmtpPort.Text);
            else check = false;

            if (txtPassword.Password != null && txtPassword.Password.Length < 50) smtpServer.EmailPassword = txtPassword.Password;
            else check = false;


            MessageBox.Show("Kayıt işlemi başarılı!");
            var myObject = this.Owner as MainWindow;
            myObject.smtpServer=smtpServer;           
            this.Close();
        }

        private bool IsValid(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
