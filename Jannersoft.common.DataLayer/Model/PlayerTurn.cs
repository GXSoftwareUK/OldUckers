namespace Jannersoft.common.DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerTurn")]
    public partial class PlayerTurn
    {
        [Key]
        [Column(Order = 0)]
        public Guid PlayerId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid GameId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TurnId { get; set; }

        public DateTime TurnDate { get; set; }

        public virtual GamePlayer GamePlayer { get; set; }

        public virtual Turn Turn { get; set; }
    }
}
