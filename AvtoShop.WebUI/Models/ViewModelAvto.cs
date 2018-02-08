using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvtoShop.WebUI.Models
{
    public class ViewModelAvto
    {
        public int AvtoId { get; set; }
        public string UserName { get; set; }
        public string BrandName { get; set; }//from Brand
        public string ModelAvtoName { get; set; }//from ModelAvto
        public int YearAvto { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

    }
}
