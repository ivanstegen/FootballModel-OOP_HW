using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FootballPlayer[] players = new FootballPlayer[]
           {
             new Goalkeeper("Ivan", 19, 1, 176),

             new Defender("Viktor", 19, 2, 182),
             new Defender("Boris", 19, 3, 175),
             new Defender("Daniel", 20, 4, 192),
             new Defender("Mert", 20, 5, 177),

             new Midfielder("Antoan D.", 20, 8, 185),
             new Midfielder("Yuroslav", 20, 6, 170),
             new Midfielder("Georgi", 20, 10, 188),

             new Striker("Antoan R.", 20, 7, 178),
             new Striker("Todor", 20, 9, 190),
             new Striker("Selmer", 21, 11, 179),


             new Goalkeeper("Thibaut Courtois", 31, 13, 200),

             new Defender("Theo Hernández", 25, 19, 184),
             new Defender("Éder Militão", 25, 3, 186),
             new Defender("Virgil van Dijk", 31, 4, 195),
             new Defender("Achraf Hakimi", 24, 2, 181),

             new Midfielder("Kylian Mbappé", 24, 7, 178),
             new Midfielder("Luka Modric", 37, 14, 172),
             new Midfielder("Kevin De Bruyne", 31, 17, 181),
             new Midfielder("Lionel Messi", 35, 10, 170),

             new Striker("Erling Haaland", 22, 9, 194),
             new Striker("Karim Benzema", 35, 11, 185),
       };


            Coach[] coaches = new Coach[]
            {
                new Coach("Pep Guardiola", 52),
                new Coach("José Mourinho", 60)
            };


            Team team1 = new Team(coaches[0], players.Take(11).ToList());
            Team team2 = new Team(coaches[1], players.Skip(11).ToList());


            Referee referee = new Referee("Georgi Kabakov", 37);
            AssistantReferee assistantReferee1 = new AssistantReferee("Anthony Taylor", 44);
            AssistantReferee assistantReferee2 = new AssistantReferee("Martin Atkinson", 52);
            List<AssistantReferee> assistantReferees = new List<AssistantReferee> { assistantReferee1, assistantReferee2 };


            Game game = new Game(team1, team2, referee, assistantReferees);
            game.AddGoal(15, players[9]);
            game.AddGoal(30, players[19]);
            game.AddGoal(60, players[20]);
            game.AddGoal(75, players[7]);
            game.AddGoal(90, players[0]);


            game.UpdateScoreline();

            Console.WriteLine("Game Result: " + game.Scoreline);

            if (game.Winner != null)
                if (game.Winner.Coach.Name == "Pep Guardiola")
                {
                    Console.WriteLine("Winner is Team1 with coach: " + game.Winner.Coach.Name);
                }
                else
                {
                    Console.WriteLine("Winner is Team2 with coach: " + game.Winner.Coach.Name);
                }

            else
                Console.WriteLine("The match ended in a draw.");

            Console.WriteLine("Average Age of Team1 Players: " + team1.GetAveragePlayerAge());


            Console.WriteLine("Average Age of Team2 Players: " + team2.GetAveragePlayerAge());
        
        }
    }
}
