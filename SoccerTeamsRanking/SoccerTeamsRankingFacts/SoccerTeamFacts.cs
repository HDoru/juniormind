using SoccerTeamsRanking;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SoccerTeamsRankingFacts
{
    public class SoccerTeamFacts
    {
        [Fact]
        public void MorePointsTest()
        {
            SoccerTeam ucluj = new SoccerTeam("UCLUJ", 19);
            SoccerTeam cfr = new SoccerTeam("CFR", 10);
            Assert.True(cfr.LessPointsThan(ucluj));
        }
    }
}
