using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
            smtpServer.EmailSmtpServer = Properties.Settings.Default.MailSmtpServer;
            smtpServer.EmailSmtpPort = Properties.Settings.Default.MailSmtpPort;
            smtpServer.EmailAddress = Properties.Settings.Default.EmailAddress;
            smtpServer.EmailPassword = Properties.Settings.Default.EmailPassword;
            smtpServer.UseSsl = Properties.Settings.Default.UseSsl;
            smtpServer.NeedNetworkCredential = Properties.Settings.Default.NeedNetworkCredential;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SmtpSettings dlgSmtpSettings = new SmtpSettings();
            dlgSmtpSettings.Owner = this;
            dlgSmtpSettings.ShowDialog();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SmtpClient sc = new SmtpClient(smtpServer.EmailSmtpServer, smtpServer.EmailSmtpPort);
                if (smtpServer.UseSsl)
                    sc.EnableSsl = true;
                if (smtpServer.NeedNetworkCredential)
                    sc.Credentials = new NetworkCredential(smtpServer.EmailAddress, smtpServer.EmailPassword);
                else
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage Mesaj = new MailMessage();
                Mesaj.Body = txtBody.Text;
                Mesaj.IsBodyHtml = chkIsHtml.IsChecked == true ? true : false;
                Mesaj.Subject = txtSubject.Text;
                Mesaj.Sender = Mesaj.From = new MailAddress(smtpServer.EmailAddress);
                Mesaj.To.Add(txtTo.Text);

                sc.Send(Mesaj);
            }
            catch(Exception ex)
            {

            }

            txtTo.Text = "";
            txtSubject.Text = "";
            txtBody.Text = "";

        }

        static void NEVER_EAT_POISON_Disable_CertificateValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        }
    }
    
}
