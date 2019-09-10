using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Name { get; set; }

        [Column(TypeName = "VARBINARY(MAX)")]
        public string LogoUrl { get; set; }

        [Column(TypeName = "CHAR(3)")]
        public string Initials { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }

        [ForeignKey(nameof(PrimaryKitColorId))]
        [InverseProperty("PrimaryKitTeams")]
        public virtual Color PrimaryKitColor { get; set; }

        [ForeignKey(nameof(SecondaryKitColorId))]
        [InverseProperty("SecondaryKitTeams")]
        public virtual Color SecondaryKitColor { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual HashSet<Game> HomeGames { get; set; }

        [InverseProperty("AwayTeam")]
        public virtual HashSet<Game> AwayGames { get; set; }

        public HashSet<Player> Players { get; set; }

        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; }
    }
}
