using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler
{
    public class ScheduleGenerator
    {
        public List<Match> GenerateMatches(List<string> teams)
        {
            List<Match> matches = new List<Match>();
            if (teams.Count < 2)
            {
                if(teams.Count < 1)
                {
                    return matches;
                }
                else
                {
                   // matches.Add(teams[0]);
                    return matches;
                }
               // teams.Count < 1 ? (return matches) : return matches.Add(teams[0]);
            }
            
        }
    }
}
