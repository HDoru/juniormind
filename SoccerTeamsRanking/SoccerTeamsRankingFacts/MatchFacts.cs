using SoccerTeamsRanking;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SoccerTeamsRankingFacts
{
  public  class MatchFacts
    {
        [Fact]
        public void  UpdateRankingForWin()
        {
            SoccerTeam ucluj = new SoccerTeam("UCLUJ", 12);
            SoccerTeam cfr = new SoccerTeam("CFR", 10);
            SoccerTeam craiova = new SoccerTeam("Craiova", 9);
            SoccerTeam[] soccerTeams = new SoccerTeam[0];
            TeamsRanking teamsRanking = new TeamsRanking(soccerTeams);
            teamsRanking.AddNewTeam(ucluj);
            teamsRanking.AddNewTeam(cfr);
            teamsRanking.AddNewTeam(craiova);
            Match match = new Match(ucluj, cfr, 0, 1);
            match.UpdateRanking();
            teamsRanking.Sort();
            Assert.Equal(0, teamsRanking.GetPositionForSoccerTeam(cfr));

        }

        [Fact]
        public void UpdateRankingForDrow()
        {
            SoccerTeam ucluj = new SoccerTeam("UCLUJ", 12);
            SoccerTeam cfr = new SoccerTeam("CFR", 10);
            SoccerTeam craiova = new SoccerTeam("Craiova", 9);
            SoccerTeam[] soccerTeams = new SoccerTeam[0];
            TeamsRanking teamsRanking = new TeamsRanking(soccerTeams);
            teamsRanking.AddNewTeam(ucluj);
            teamsRanking.AddNewTeam(cfr);
            teamsRanking.AddNewTeam(craiova);
            Match match = new Match(ucluj, craiova, 1, 1);
            match.UpdateRanking();
            Assert.True(cfr.LessPointsThan(ucluj));

        }

    }
}
