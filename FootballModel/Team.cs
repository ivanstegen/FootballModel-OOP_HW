using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballModel
{
   public class Team
    {
        public Coach Coach { get; private set; }
        private List<FootballPlayer> _players;

        public IReadOnlyList<FootballPlayer> Players => _players;

        public Team(Coach coach, List<FootballPlayer> players)
        {
            if (players.Count < 11 || players.Count > 22)
            {
                throw new ArgumentException("A team must have a minimum of 11 players and a maximum of 22 players.");
            }

            Coach = coach;
            _players = players;
        }

        public double GetAveragePlayerAge()
        {
            int totalAge = 0;
            foreach (var player in _players)
            {
                totalAge += player.Age;
            }
            return (int)totalAge / _players.Count;
        }

    }
}
