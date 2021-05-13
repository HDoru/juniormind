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

        public void Play(SoccerTeam hometeam,int hometeamgoals, SoccerTeam awayteam, int awayteamgoals)
        {
            Match match = new Match(hometeam, awayteam, hometeamgoals, awayteamgoals);
            match.UpdateRanking();
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
            for (int i = 0; i < soccerTeams.Length - 1; i++)
            {
                bool swap = true;
                for (int j = 0; (j < soccerTeams.Length - 1) && swap; j++)
                {
                    if (soccerTeams[j].LessPointsThan(soccerTeams[j + 1]))
                    {
                        Swap(j, j + 1);
                        swap = false;
                    }
                }

            }
        }

         void Swap( int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);

            SoccerTeam temp = soccerTeams[minIndex];
            soccerTeams[minIndex] = soccerTeams[maxIndex];
            soccerTeams[maxIndex] = temp;
        }

        static (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }


    }

    
}
