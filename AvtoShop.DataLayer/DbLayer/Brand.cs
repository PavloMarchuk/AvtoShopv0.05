namespace AvtoShop.DataLayer.DbLayer
{
    using AvtoShop.DataLayer.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Brand")]
    public partial class Brand : EntityExtension<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            ModelAvtoes = new HashSet<ModelAvto>();
        }
        [Column("BrandId", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [StringLength(64)]
        [Column("BrandName", TypeName = "string")]
        public override string Name { get; set; }
        //public int BrandId { get; set; }

        //[Required]
        //[StringLength(64)]
        //public string BrandName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModelAvto> ModelAvtoes { get; set; }
    }
}
