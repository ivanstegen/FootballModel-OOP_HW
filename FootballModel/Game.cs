using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballModel
{
    public class Game
    {
        public Team Team1 { get; private set; }
        public Team Team2 { get; private set; }
        public Referee Referee { get; private set; }
        public List<AssistantReferee> AssistantReferees { get; private set; }
        public List<Goal> Goals { get; private set; } = new List<Goal>();
        public string Scoreline { get; private set; }
        public Team Winner { get; private set; }

        public Game(Team team1, Team team2, Referee referee, List<AssistantReferee> assistantReferees)
        {
            if (team1.Players.Count != 11 || team2.Players.Count != 11)
            {
                throw new ArgumentException("Each team must have exactly 11 players.");
            }

            if (assistantReferees.Count != 2)
            {
                throw new ArgumentException("A game must have exactly two assistant referees.");
            }

            Team1 = team1;
            Team2 = team2;
            Referee = referee;
            AssistantReferees = assistantReferees;
            Goals = new List<Goal>();
            Scoreline = "0 - 0";
            Winner = null;
        }

        public void AddGoal(int minute, FootballPlayer player)
        {
            Goal goal = new Goal(minute, player);
            Goals.Add(goal);
            UpdateScoreline();
        }

        public void UpdateScoreline()
        {
            int team1Goals = Goals.Count(goal => Team1.Players.Contains(goal.Player));
            int team2Goals = Goals.Count(goal => Team2.Players.Contains(goal.Player));
            Scoreline = $"{team1Goals} - {team2Goals}";

            if (team1Goals > team2Goals)
                Winner = Team1;
            else if (team2Goals > team1Goals)
                Winner = Team2;
            else
                Winner = null;
        }
    }
}
