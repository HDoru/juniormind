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

        [Fact]
        public void  GetSoccerTeamFromSpecificIndex()
        {
            SoccerTeam ucluj = new SoccerTeam("UCLUJ", 19);
            SoccerTeam[] soccerTeams = new SoccerTeam[1];
            TeamsRanking teamsRanking = new TeamsRanking(soccerTeams);
            soccerTeams[0] = ucluj;
            Assert.Equal(ucluj, teamsRanking.GetValueFromSpecificIndex(0));

        }

        [Fact]
        public void GetSpecificIndexForSoccerTeam()
        {
            SoccerTeam ucluj = new SoccerTeam("UCLUJ", 19);
            SoccerTeam cfr = new SoccerTeam("CFR", 10);
            SoccerTeam craiova = new SoccerTeam("Craiova", 7);
            SoccerTeam[] soccerTeams = new SoccerTeam[2];
            TeamsRanking teamsRanking = new TeamsRanking(soccerTeams);
            soccerTeams[0] = ucluj;
            soccerTeams[1] = cfr;
            Assert.Equal(1, teamsRanking.GetPositionForSoccerTeam(cfr));
            Assert.Equal(0, teamsRanking.GetPositionForSoccerTeam(ucluj));
            Assert.Equal(-1, teamsRanking.GetPositionForSoccerTeam(craiova));
            

        }

        [Fact]
        public void SortingRanking()
        {
            SoccerTeam ucluj = new SoccerTeam("UCLUJ", 19);
            SoccerTeam cfr = new SoccerTeam("CFR", 10);
            SoccerTeam craiova = new SoccerTeam("Craiova", 7);
            SoccerTeam[] soccerTeams = new SoccerTeam[3];
            TeamsRanking teamsRanking = new TeamsRanking(soccerTeams);
            soccerTeams[0] = ucluj;
            soccerTeams[1] = craiova;
            soccerTeams[2] = cfr;
            teamsRanking.Sort();
            Assert.Equal(0, teamsRanking.GetPositionForSoccerTeam(ucluj));
            Assert.Equal(1, teamsRanking.GetPositionForSoccerTeam(cfr));
            Assert.Equal(2, teamsRanking.GetPositionForSoccerTeam(craiova));

        }




    }
}
