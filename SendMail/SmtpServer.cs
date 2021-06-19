using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SendMail
{
    [DataContract]
    public class SmtpServer
    {
        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string EmailSmtpServer { get; set; }

        [DataMember]
        public int EmailSmtpPort { get; set; }

        [DataMember]
        public string EmailPassword { get; set; }

    }
}
