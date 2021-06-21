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
                return matches;
            }

            if (teams.Count % 2 != 0)
            {
                teams.Add("Bye");
            }

            for (int i = 0; i < teams.Count - 1; i++)
            {
                var teamsInSingleRound = RoundCalculator(teams, i + 1);
                string lastTeam = teams[teams.Count - 1];
                teams.RemoveAt(teams.Count - 1);
                teams.Insert(1, lastTeam);
                foreach (var team in teamsInSingleRound)
                {
                    matches.Add(team);
                }

            }

            return matches;
        }
        static List<Match> RoundCalculator(List<string> teams, int roundNo)
        {
            List<Match> pairedTeams = new List<Match> { };

            for (int i = 0; i < teams.Count / 2; i++)
            {
                if ((roundNo % 2 == 0 && i == 0))
                {
                    pairedTeams.Add(new Match(teams[^(i + 1)], teams[i], roundNo));
                }
                else
                {
                    pairedTeams.Add(new Match(teams[i], teams[^(i + 1)], roundNo));
                }

            }

            return pairedTeams;
        }

    }
}
