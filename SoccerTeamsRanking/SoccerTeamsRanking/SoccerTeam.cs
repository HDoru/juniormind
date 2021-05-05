using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerTeamsRanking
{
    class SoccerTeam
    {
        private int id { get; set; }
        private string name { get; set; }


        public SoccerTeam(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        SoccerTeam soccerTeam1 = new SoccerTeam(1, "FCSB");
    }
}
