using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }

        [StringLength(100)]
        [DisplayName("Başlık Adı")]
        public string HeadingName { get; set; }
        [DisplayName("Tarih")]
        public DateTime HeadingDate { get; set; }
        [DisplayName("Aktif mi?")]
        public bool isActive { get; set; }

        public int CategoryId { get; set; }                //Bir kategoriye ait

        public virtual Category Category { get; set; }     //birden fazla başlık olabilir 1-N

        public ICollection<Content> Contents { get; set; }  // Bir başlık birden fazla içeriğe sahip olabilir. 1-N

        public int WriterId { get; set; }           //Birden fazla başlığın sahibi                                             
        public virtual Writer Writer { get; set; }   //bir yazar olabilir 1-N
    }
}
