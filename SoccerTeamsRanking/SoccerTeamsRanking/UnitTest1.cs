using System;
using Xunit;

namespace SoccerTeamsRanking
{
    public class UnitTest1
    {
       
        public void Test1()
        {
            SoccerTeam[] soccerTeam = new SoccerTeam[2];
            TeamsRanking teamsRanking = new TeamsRanking(soccerTeam);
            SoccerTeam fcsb = new SoccerTeam("FCSB", 12);

            Console.WriteLine(teamsRanking.ToString());
         
            ;



        }
    }
}
