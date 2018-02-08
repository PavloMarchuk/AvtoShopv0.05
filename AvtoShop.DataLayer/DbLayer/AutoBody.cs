namespace AvtoShop.DataLayer.DbLayer
{
    using AvtoShop.DataLayer.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("AutoBody")]
    public partial class AutoBody:  EntityExtension<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AutoBody()
        {
            Avtoes = new HashSet<Avto>();
        }
        [Column("AutoBodyId", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [StringLength(64)]
        [Column("AutoBodyName", TypeName = "string")]
        public override string Name { get; set; }
        //public int AutoBodyId { get; set; }

        //[Required]
        //[StringLength(64)]
        //public string AutoBodyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avto> Avtoes { get; set; }
    }
}
