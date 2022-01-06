using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [StringLength(50)]
        [DisplayName("Gönderici Adresi")]
        public string SenderMail { get; set; }
        [StringLength(50)]
        [DisplayName("Alıcı Adresi")]
        public string ReceiverMail { get; set; }

        [StringLength(100)]
        [DisplayName("Konu")]
        public string Subject { get; set; }
        [DisplayName("Mesaj")]
        public string MessageContent { get; set; }
        [DisplayName("Tarih")]
        public DateTime MessageDate { get; set; }
    }
}
