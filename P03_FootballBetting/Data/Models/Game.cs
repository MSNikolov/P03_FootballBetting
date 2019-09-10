using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();

            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }
            
        public int HomeTeamId { get; set; }

        [ForeignKey(nameof(HomeTeamId))]
        [InverseProperty("HomeGames")]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        [InverseProperty("AwayGames")]
        public virtual Team AwayTeam { get; set; }
        
        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        [Column (TypeName = "DECIMAL(18,2)")]
        public decimal HomeTeamBetRate { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal AwayTeamBetRate { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal DrawBetRate { get; set; }

        public Result  Result
        {
            get
            {
                if (this.HomeTeamGoals > this.AwayTeamGoals)
                {
                    return Result.HomeTeam;
                }
                else if (this.HomeTeamGoals < this.AwayTeamGoals)
                {
                    return Result.AwayTeam;
                }
                else
                {
                    return Result.Draw;
                }
            }
        }

        public HashSet<PlayerStatistic> PlayerStatistics { get; set; }

        public HashSet<Bet> Bets { get; set; }
    }
}
