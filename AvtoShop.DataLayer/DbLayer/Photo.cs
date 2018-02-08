namespace AvtoShop.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Photo")]
    public partial class Photo
    {
        public int PhotoId { get; set; }

        public int? AvtoId { get; set; }

        [Required]
        [StringLength(512)]
        public string PhotoPath { get; set; }

        public virtual Avto Avto { get; set; }
    }
}
