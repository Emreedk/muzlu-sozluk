using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        [DisplayName("Entry")]
        public string ContentValue { get; set; }
        [DisplayName("Tarih")]
        public DateTime ContentDate { get; set; }
        [DisplayName("Aktif mi ?")]
        public bool isActive { get; set; }

        public int HeadingId { get; set; }                  //Bir başlığın altında
                                                           
        public virtual Heading Heading { get; set; }        //birden çok içerik olabilir 1-N


        public int? WriterId { get; set; }             //Bir yazar 
        public  virtual Writer  Writer { get; set; } //birden fazla içerik yazabilir. 1-N


    }
}
