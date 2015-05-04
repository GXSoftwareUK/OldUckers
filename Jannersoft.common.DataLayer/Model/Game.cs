namespace Jannersoft.common.DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public Game()
        {
            GamePlayers = new HashSet<GamePlayer>();
        }

        public Guid GameId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
