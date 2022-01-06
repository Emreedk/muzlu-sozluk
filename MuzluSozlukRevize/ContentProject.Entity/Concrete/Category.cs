using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]

        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }

        [StringLength(200)]
        [DisplayName("Açıklama")]
        public string CategoryDescription { get; set; }
        [DisplayName("Aktif mi?")]
        public bool CategoryStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }  // Bir kategori'ye ait birden fazla başlık olabilir 1-N
    }
}
