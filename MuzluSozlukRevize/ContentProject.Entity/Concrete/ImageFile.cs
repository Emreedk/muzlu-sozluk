using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
    public class ImageFile
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(100)]
        [DisplayName("Fotoğraf Adı")]
        public string ImageName { get; set; }

        [StringLength(250)]
        [DisplayName("Fotoğraf Adresi")]
        public string ImagePath { get; set; }
    }
}
