using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler
{
    public class Match
    {
        public int Round { get; set; }
        public string HomeTeam { get; }
        public string AwayTeam { get; }

       
        public Match(string homeTeam, string awayTeam, int round)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Round = round;
        }
    }
}
