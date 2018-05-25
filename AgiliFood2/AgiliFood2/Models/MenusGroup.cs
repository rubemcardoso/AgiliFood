namespace AgiliFood2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenusGroup")]
    public partial class MenusGroup
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal ProductPrice { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string MenuName { get; set; }

        public int? DayOfWeek { get; set; }
    }
}
