using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Career
{
    public class SendMail
    {
        public string  To { get; set; }
        public string ReceiveName { get; set; }
        public string  Subject { get; set; }
        public string Message { get; set; }
    }
}
