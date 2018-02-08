namespace AvtoShop.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("ModelAvto")]
    public partial class ModelAvto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModelAvto()
        {
            Avtoes = new HashSet<Avto>();
        }

        public int ModelAvtoId { get; set; }

        public int? BrandId { get; set; }

        [Required]
        [StringLength(64)]
        public string ModelName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avto> Avtoes { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
