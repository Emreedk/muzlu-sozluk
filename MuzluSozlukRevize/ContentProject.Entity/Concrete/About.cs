using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Concrete
{
    public class About
    {

        [Key]
        public int AboutID { get; set; }
        [StringLength(1000)]
        [DisplayName("Hakkında 1")]
        public string AboutDetails1 { get; set; }
        [StringLength(1000)]
        [DisplayName("Hakkında 2")]
        public string AboutDetails2 { get; set; }
        [StringLength(100)]
        [DisplayName("Hakkında Görseli 1")]
        public string AboutImage1 { get; set; }
        [StringLength(100)]
        [DisplayName("Hakkında Görseli 2")]

        public string AboutImage2 { get; set; }
    }
}
