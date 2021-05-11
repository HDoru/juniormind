using SoccerTeamsRanking;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SoccerTeamsRankingFacts
{
    public class SoccerteamsRankingFacts
    {

        [Fact]
        public void AddTeamsToRanking()
        {

            SoccerTeam ucluj = new SoccerTeam("UCLUJ",19);
            SoccerTeam cfr = new SoccerTeam("CFR", 10);
            SoccerTeam[] soccerTeams = new SoccerTeam[0];
            TeamsRanking teamsRanking = new TeamsRanking(soccerTeams);
            teamsRanking.AddNewTeam(ucluj);
            teamsRanking.AddNewTeam(cfr);
            Assert.Equal(ucluj,teamsRanking.GetValueFromSpecificIndex(0));
            



        }
    }
}
