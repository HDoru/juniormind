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
        public void Test1()
        {
            SoccerTeam s1 = new SoccerTeam("FCSB", 12);
            SoccerTeam s2 = new SoccerTeam("CFR", 10);
            SoccerTeam s3 = new SoccerTeam("CSU", 15);
            SoccerTeam[] soccerTeam = new SoccerTeam[2];
            SoccerTeam[] soccerTeam1 = new SoccerTeam[3];

            TeamsRanking teamsRanking = new TeamsRanking(soccerTeam);
            soccerTeam[0] = s1;
            soccerTeam[1] = s2;

            soccerTeam1[0] = s1;
            soccerTeam1[1] = s2;
            soccerTeam1[2] = s3;


            TeamsRanking teamsRanking2 = new TeamsRanking(soccerTeam1);



           

            Assert.Equal(teamsRanking2, teamsRanking.AddNewTeam(s3, soccerTeam));

           
              
            


           

            
            
            


          

            

            ;



        }
    }
}
