using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerTeamsRanking
{
   public class Match
    {
        private SoccerTeam hometeam;
        private SoccerTeam awayteam;
        private int hometeamgoals;
        private int awayteamgoals;

        public Match(SoccerTeam hometeam, SoccerTeam awayteam,int hometeamgoals, int awayteamgoals)
        {
            this.hometeam = hometeam;
            this.awayteam = awayteam;
            this.hometeamgoals = hometeamgoals;
            this.awayteamgoals = awayteamgoals;
        }

        public void UpdateRanking()
        {
            if(hometeamgoals > awayteamgoals)
            {
                hometeam.AddPointsToTeam(3);
            }
            else if (hometeamgoals < awayteamgoals)
            {
                awayteam.AddPointsToTeam(3);
            }
            else
            {
                hometeam.AddPointsToTeam(1);
                awayteam.AddPointsToTeam(1);
            }

        }
    }
}
