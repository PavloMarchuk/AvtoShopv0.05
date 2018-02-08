namespace AvtoShop.DataLayer.DbLayer
{
    using AvtoShop.DataLayer.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("KPP")]
    public partial class KPP : EntityExtension<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KPP()
        {
            Avtoes = new HashSet<Avto>();
        }
        [Column("KPPId", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [StringLength(32)]
        [Column("KPPName", TypeName = "string")]
        public override string Name { get; set; }
       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avto> Avtoes { get; set; }
    }
}
