namespace Jannersoft.common.DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Turn")]
    public partial class Turn
    {
        public Turn()
        {
            PlayerTurns = new HashSet<PlayerTurn>();
        }

        public int TurnId { get; set; }

        public int UckerId { get; set; }

        [Required]
        public DbGeometry StartPoint { get; set; }

        [Required]
        public DbGeometry EndPoint { get; set; }

        public int DiceAResult { get; set; }

        public int DiceBResult { get; set; }

        public virtual ICollection<PlayerTurn> PlayerTurns { get; set; }
    }
}
