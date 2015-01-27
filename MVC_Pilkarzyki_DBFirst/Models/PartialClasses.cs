using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Pilkarzyki_DBFirst.Models
{
    [MetadataType(typeof(TeamsMetadata))]
    public partial class Teams
    {

    }

    [MetadataType(typeof(ScoresMetadata))]
    public partial class Scores
    {

    }

    [MetadataType(typeof(v_TeamWinsStatsMetadata))]
    public partial class v_TeamWinsStats
    {

    }

    [MetadataType(typeof(v_PlayerWinsStatsMetadata))]
    public partial class v_PlayerWinsStats
    {

    }
}





