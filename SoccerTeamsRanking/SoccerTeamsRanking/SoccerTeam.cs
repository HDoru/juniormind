﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerTeamsRanking
{
   public  class SoccerTeam
    {

        private  string name;

        private  int points;


        public SoccerTeam(string name, int points)
        {
            
            this.name = name;
            this.points = points;
        }

       public  bool MorePoints( SoccerTeam soccerTeam)
        {
            return points < soccerTeam.points;
        }

        public void AddPointsToTeam(int pointstoadd)
        {
             points +=pointstoadd;
        }
   
    }
}
