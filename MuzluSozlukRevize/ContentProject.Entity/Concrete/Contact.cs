using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
   public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(50)]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [StringLength(50)]
        [DisplayName("Mail Adresi")]
        public string UserMail { get; set; }

        [StringLength(50)]
        [DisplayName("Konu")]
        public string Subject { get; set; }
        [DisplayName("Tarih")]
        public DateTime ContactDate { get; set; }
        [DisplayName("Mesaj")]

        public string Message { get; set; }
    }
}
