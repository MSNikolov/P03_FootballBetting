using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }
        [Key]
        public int ColorId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [InverseProperty("PrimaryKitColor")]
        public virtual HashSet<Team> PrimaryKitTeams { get; set; }

        [InverseProperty("SecondaryKitColor")]
        public virtual HashSet<Team> SecondaryKitTeams { get; set; }
    }
}
