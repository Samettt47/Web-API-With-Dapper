using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogAppEntitites
{
    public class Yazilar
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YazilarID { get; set; }

        public int KategoriId { get; set; }

        public string Kategori { get; set; }
         
        public string Yazilarr { get; set; }


        
    }
}
