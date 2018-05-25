namespace AgiliFood2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        public DateTime RegisterDate { get; set; }

        public Status Status { get; set; }

        public int SupplierID { get; set; }

        public int MenuID { get; set; }

        public virtual Menus Menus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }

        public virtual Suppliers Suppliers { get; set; }
    }
}
