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

        public void AddNewTeam(SoccerTeam soccerTeam)
        {
            SoccerTeam[] newSoccerTeams = new SoccerTeam[soccerTeams.Length];
            Array.Copy(soccerTeams, newSoccerTeams, soccerTeams.Length);
            Array.Resize(ref newSoccerTeams, soccerTeams.Length + 1);
            newSoccerTeams[soccerTeams.Length] = soccerTeam;
            soccerTeams = newSoccerTeams;

        }

        public SoccerTeam GetValueFromSpecificIndex(int index)
        {
            return soccerTeams[index];
        }

        public int GetPositionForSoccerTeam(SoccerTeam soccerTeam)
        {
            for (int i = 0; i <= soccerTeams.Length-1; i++)
            {
                if(soccerTeams[i] == soccerTeam)
                {
                    return i;
                }
            }
            return -1;

        }
    }

    
}
