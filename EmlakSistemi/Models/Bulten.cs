namespace EmlakSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bulten")]
    public partial class Bulten
    {
        [Key]
        public int Bulten_ID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
