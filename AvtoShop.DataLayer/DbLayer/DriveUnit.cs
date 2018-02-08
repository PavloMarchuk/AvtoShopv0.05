namespace AvtoShop.DataLayer.DbLayer
{
    using AvtoShop.DataLayer.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("DriveUnit")]
    public partial class DriveUnit : EntityExtension<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DriveUnit()
        {
            Avtoes = new HashSet<Avto>();
        }
        [Column("DriveUnitId", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [StringLength(32)]
        [Column("DriveUnitName", TypeName = "string")]
        public override string Name { get; set; }
        //public int DriveUnitId { get; set; }

        //[Required]
        //[StringLength(32)]
        //public string DriveUnitName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avto> Avtoes { get; set; }
    }
}
