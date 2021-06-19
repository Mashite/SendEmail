using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SmtpServer smtpServer = new SmtpServer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SmtpSettings dlgSmtpSettings = new SmtpSettings();
            dlgSmtpSettings.Owner = this;
            dlgSmtpSettings.ShowDialog();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = smtpServer.EmailSmtpPort;
            sc.Host = smtpServer.EmailSmtpServer;
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential(smtpServer.EmailAddress, smtpServer.EmailPassword);

            MailMessage Mesaj = new MailMessage();
            Mesaj.Body = txtBody.Text;
            Mesaj.IsBodyHtml = chkIsHtml.IsChecked == true ? true : false;
            Mesaj.Subject = txtSubject.Text;
            Mesaj.Sender = Mesaj.From = new MailAddress(smtpServer.EmailAddress);
            Mesaj.To.Add(txtTo.Text);           

            sc.Send(Mesaj);

            txtTo.Text = "";
            txtSubject.Text = "";
            txtBody.Text = "";
        }
    }

    
}
