    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogAppEntitites
{

    [Table("Kategorilerr")]
    public class Kategorilerr
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KategoriID { get; set; }
        public string Kategoriler { get; set; }

        public List<Yazilar> Yazilar { get; set; } = new List<Yazilar>();
    }
}
