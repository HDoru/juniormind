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
                hometeam.AddPoints(3);
            }
            else if (hometeamgoals < awayteamgoals)
            {
                awayteam.AddPoints(3);
            }
            else
            {
                hometeam.AddPoints(1);
                awayteam.AddPoints(1);
            }

        }
    }
}
