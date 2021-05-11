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
                bool swap = false;

                for (int j = 0; j < soccerTeams.Length - i - 1; j++)
                {
                    if ( soccerTeams[j].MorePoints(soccerTeams[j+1]))
                    {
                        Swap(soccerTeams, j, j + 1);
                        swap = true;
                    }
                }

                if (!swap)
                {
                    break;
                }
            }
        }

        void Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);

            SoccerTeam temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
        }

         (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }
    }

    
}
