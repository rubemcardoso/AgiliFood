namespace AgiliFood2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Financial")]
    public partial class Financial
    {
        [Key]
        [Column("Order Number", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_Number { get; set; }

        [Key]
        [Column("Order Date", Order = 1)]
        public DateTime Order_Date { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public string Employee { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(150)]
        public string Product { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        [Key]
        [Column("Unit Price", Order = 7)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Unit_Price { get; set; }

        [Column("Total Product")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Total_Product { get; set; }
    }
}
