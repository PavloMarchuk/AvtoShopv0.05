using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvtoShop.WebUI.Models
{
    public class ViewModelModelAvto
    {
        public int ModelAvtoId { get; set; }

        public string BrandName { get; set; }

        public string ModelName { get; set; }

    }
}
