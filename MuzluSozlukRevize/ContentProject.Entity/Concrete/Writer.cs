using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
    public class Writer
    {

        [Key]
        
        public int WriterId { get; set; }

        [StringLength(50)]

        [DisplayName("Yazar Adı")]
        public string WriterName { get; set; }

        [StringLength(50)]
        [DisplayName("Yazar Soyadı")]
        public string WriterSurname { get; set; }

        [StringLength(50)]
        [DisplayName("Kullanıcı Adı")]
        public string WriterUsername { get; set; }
        [DisplayName("Admin mi?")]
        public bool isAdmin { get; set; }
        [DisplayName("Aktif mi?")]
        public bool isActive { get; set; }

        [StringLength(100)]
        [DisplayName("Fotoğraf")]
        public string WriterImage { get; set; }

        [StringLength(200)]
        [DisplayName("Yazar Hakkında")]
        public string WriterAbout { get; set; }

        [StringLength(30)]
        [DisplayName("Mail Adresi")]
        public string WriterMail { get; set; }

        [StringLength(12)]
        [DisplayName("Şifre")]
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; } //Bir yazar birden çok başlık açabilir 1-N

        public ICollection<Content> Contents { get; set; }  //Bir yazar birden fazla içerik yazabilir 1-N
    }
}
