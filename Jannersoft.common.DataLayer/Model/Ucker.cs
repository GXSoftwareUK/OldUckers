namespace Jannersoft.common.DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ucker")]
    public partial class Ucker
    {
        public Ucker()
        {
            GamePlayers = new HashSet<GamePlayer>();
        }

        public int UckerId { get; set; }

        [Required]
        [StringLength(10)]
        public string ColourName { get; set; }

        [Required]
        [StringLength(10)]
        public string ColourCode { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
