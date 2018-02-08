namespace AvtoShop.DataLayer.DbLayer
{
    using AvtoShop.DataLayer.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Fuel")]
    public partial class Fuel : EntityExtension<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fuel()
        {
            Avtoes = new HashSet<Avto>();
        }

        [Column("FuelId", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [StringLength(32)]
        [Column("FuelName", TypeName = "string")]
        public override string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avto> Avtoes { get; set; }
    }
}
