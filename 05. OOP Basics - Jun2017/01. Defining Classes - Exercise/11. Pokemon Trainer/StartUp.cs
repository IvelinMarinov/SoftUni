using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Pokemon_Trainer
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                var inputArgs = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var trainerName = inputArgs[0];
                var pokemonName = inputArgs[1];
                var pokemonElement = inputArgs[2];
                var pokemonHealth = int.Parse(inputArgs[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (trainers.Any(t => t.Name == trainerName))
                {
                    var currTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                    currTrainer.Pokemons.Add(pokemon);
                }

                else
                {
                    var trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }

                input = Console.ReadLine();
            }

            var command = Console.ReadLine();
            var element = string.Empty;

            while (command != "End")
            {
                switch (command)
                {
                    case "Fire":
                        element = "Fire";
                        ProcessElementEffect(element, trainers);
                        break;
                    case "Water":
                        element = "Water";
                        ProcessElementEffect(element, trainers);
                        break;
                    case "Electricity":
                        element = "Electricity";
                        ProcessElementEffect(element, trainers);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        private static void ProcessElementEffect(string element, List<Trainer> trainers)
        {
            var winningTrainers = trainers
                .Where(t => t.Pokemons.Any(p => p.Element == element))
                .ToList();

            winningTrainers.ForEach(t => t.Badges++);

            var losingTrainers = trainers
                .Where(t => t.Pokemons.All(p => p.Element != element))
                .ToList();

            for (int i = 0; i < losingTrainers.Count; i++)
            {
                for (int j = 0; j < losingTrainers[i].Pokemons.Count; j++)
                {
                    losingTrainers[i].Pokemons[j].Health -= 10;
                    if (losingTrainers[i].Pokemons[j].Health <= 0)
                    {
                        losingTrainers[i].Pokemons.Remove(losingTrainers[i].Pokemons[j]);
                    }
                }
            }
        }
    }
}