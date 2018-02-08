namespace AvtoShop.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Avto")]
    public partial class Avto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Avto()
        {
            Photos = new HashSet<Photo>();
        }

        public int AvtoId { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public int? ModelAvtoId { get; set; }

        public int? AutoBodyId { get; set; }

        public int YearAvto { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Engine { get; set; }

        public int? FuelId { get; set; }

        public int? KPPId { get; set; }

        public int? DriveUnitId { get; set; }

        [StringLength(1024)]
        public string StateAvto { get; set; }

        [Required]
        [StringLength(2048)]
        public string Description { get; set; }

        [StringLength(512)]
        public string Remark { get; set; }

        public virtual AutoBody AutoBody { get; set; }

        public virtual DriveUnit DriveUnit { get; set; }

        public virtual Fuel Fuel { get; set; }

        public virtual KPP KPP { get; set; }

        public virtual ModelAvto ModelAvto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
