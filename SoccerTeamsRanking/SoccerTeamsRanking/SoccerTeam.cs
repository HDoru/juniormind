using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerTeamsRanking
{
   public  class SoccerTeam
    {

        private readonly string name;

        private readonly int points;


        public SoccerTeam(string name, int points)
        {
            
            this.name = name;
            this.points = points;
        }

   
    }
}
