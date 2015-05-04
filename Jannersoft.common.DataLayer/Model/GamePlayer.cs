namespace Jannersoft.common.DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GamePlayer
    {
        public GamePlayer()
        {
            PlayerTurns = new HashSet<PlayerTurn>();
            Uckers = new HashSet<Ucker>();
        }

        [Key]
        [Column(Order = 0)]
        public Guid GameId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid PlayerId { get; set; }

        public bool IsOwner { get; set; }

        public virtual Game Game { get; set; }

        public virtual Player Player { get; set; }

        public virtual ICollection<PlayerTurn> PlayerTurns { get; set; }

        public virtual ICollection<Ucker> Uckers { get; set; }
    }
}
