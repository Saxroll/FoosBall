using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Pilkarzyki_DBFirst.Models
{
    public class TeamsMetadata
    {
        [StringLength(100)]
        [Display(Name = "Nazwa Drużyny")]
        public string TeamName;

        [Display(Name = "Bramkarz")]
        public int GoalKeeperID;

        [Display(Name = "Atakujący")]
        public int AttackerID;
    }

    public class ScoresMetadata
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data wyniku")]
        public DateTime ModifiedDate;

        [Display(Name = "Pierwsza drużyna")]
        public int FirstTeamID;
                
        [Display(Name = "Druga drużyna")]
        public int SecondTeamID;

        [Display(Name = "Wynik pierwszej drużyny")]
        public int FirstTeamScore;

        [Display(Name = "Wynik drugiej drużyny")]
        public int SecondTeamScore;
    }

    public class v_TeamWinsStatsMetadata
    {
         [Display(Name = "Drużyna")]
        public string WinningTeamName;

        [Display(Name = "Ilość wygranych")]
        public Nullable<int> WinsCount;

        [Display(Name = "Rozegrane gry")]
        public Nullable<int> PlayedGamesCount;

        [Display(Name = "Procent wygranych")]
        public Nullable<int> PercentageOfWins;
    }

    public class v_PlayerWinsStatsMetadata
    {
        [Display(Name = "Gracz")]
        public string WinnerName ;

        [Display(Name = "Ilość wygranych")]
        public Nullable<int> WinsCount;

        [Display(Name = "Rozegrane gry")]
        public Nullable<int> GamesPlayed;

        [Display(Name = "Procent wygranych")]
        public Nullable<int> WinsPercentage;
    }
}



