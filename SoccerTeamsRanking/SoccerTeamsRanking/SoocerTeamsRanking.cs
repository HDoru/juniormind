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
            SoccerTeam[] temp= soccerTeams;
            Array.Resize(ref temp, soccerTeams.Length + 1);
            temp[soccerTeams.Length] = soccerTeam;
            soccerTeams = temp;
            Sort();




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
        public void Sort()
        {
            SoccerTeam temp;
            for (int j = 0; j <= soccerTeams.Length - 2; j++)
            {
                for (int i = 0; i <= soccerTeams.Length - 2; i++)
                {
                    if (soccerTeams[i].LessPointsThan(soccerTeams[i + 1])){
                        temp = soccerTeams[i + 1];
                        soccerTeams[i + 1] = soccerTeams[i];
                        soccerTeams[i] = temp;
                    }
                }
            }
        }


    }

    
}
