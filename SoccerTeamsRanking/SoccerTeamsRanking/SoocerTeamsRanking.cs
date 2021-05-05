using System;
using System.Collections.Generic;
using System.Text;
using SoccerTeamsRanking;


namespace SoccerTeamsRanking
{
    class SoccerTeamsRanking
    {
        private int position { get; set; }
        private SoccerTeam []soccerTeams { get; set; }
        private int points { get; set; }

        public SoccerTeamsRanking(int position, SoccerTeam []soccerTeams, int points)
        {
            this.position = position;
            this.soccerTeams = soccerTeams;
            this.points = points;
        }

       
       
    }
}
