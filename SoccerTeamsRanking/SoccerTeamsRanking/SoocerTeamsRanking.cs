using System;
using System.Collections.Generic;
using System.Text;
using SoccerTeamsRanking;


namespace SoccerTeamsRanking
{
    public class TeamsRanking
    {

       private SoccerTeam[] soccerTeams { get; set; }
       
      

        public TeamsRanking( SoccerTeam []soccerTeams)
        {
          
           
            this.soccerTeams = soccerTeams;
            
        }





     

    
        public TeamsRanking AddNewTeam(SoccerTeam soccerTeam,SoccerTeam [] soccerTeamsRanking)
        {
            SoccerTeam[] newTeamList = new SoccerTeam[soccerTeamsRanking.Length+ 1];
            int position = newTeamList.Length;

            for (int i = 0; i < soccerTeamsRanking.Length + 1; i++)
            {
                if (i < position - 1)
                    newTeamList[i] = soccerTeamsRanking[i];
                else if (i == position - 1)
                    newTeamList[i] = soccerTeam;
            }



            return new TeamsRanking(newTeamList);

        }



        


     

        
    }

    
}
