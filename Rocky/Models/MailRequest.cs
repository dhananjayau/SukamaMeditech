using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string subject { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string service { get; set; }
        public string form_message { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
