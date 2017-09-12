using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Pet_Clinics
{
    public class StartUp
    {
        private static Dictionary<string, Pet> allPets = new Dictionary<string, Pet>();
        private static Dictionary<string, Clinic> allClinics = new Dictionary<string, Clinic>();

        public static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var commandType = commandArgs[0];
                commandArgs.RemoveAt(0);

                switch (commandType)
                {
                    case "Create":
                        CreateEntity(commandArgs);
                        break;
                    case "Add":
                        Console.WriteLine(AddPetToClinic(commandArgs)); ;
                        break;
                    case "Release":
                        Console.WriteLine(ReleasePetFromClinic(commandArgs[0]));
                        break;
                    case "HasEmptyRooms":
                        Console.WriteLine(CheckForEmptyRooms(commandArgs[0]));
                        break;
                    case "Print":
                        Console.WriteLine(PrintClinicInfo(commandArgs));
                        break;
                }
            }
        }

        private static string PrintClinicInfo(List<string> commandArgs)
        {
            Clinic currentClinic = allClinics[commandArgs[0]];
            var result = string.Empty;

            if (commandArgs.Count == 1)
            {
                result = currentClinic.Print();
            }
            else
            {
                var roomIndex = int.Parse(commandArgs[1]) - 1;
                result = currentClinic.Print(roomIndex);
            }

            return result;
        }

        private static bool CheckForEmptyRooms(string clinicName)
        {
            Clinic currentClinic = allClinics[clinicName];
            return currentClinic.HasEmptyRooms();
        }

        private static bool ReleasePetFromClinic(string clinicName)
        {
            Clinic currentClinic = allClinics[clinicName];
            return currentClinic.TryReleasePet();
        }

        private static bool AddPetToClinic(List<string> commandArgs)
        {
            var petName = commandArgs[0];
            var clinicName = commandArgs[1];

            Pet currentPet = allPets[petName];
            Clinic currentClinic = allClinics[clinicName];

            if (currentClinic.TryAddPet(currentPet))
            {
                allPets.Remove(petName);
                return true;
            }

            return false;
        }

        private static void CreateEntity(List<string> commandArgs)
        {
            var entityType = commandArgs[0];

            if (entityType == "Pet")
            {
                var name = commandArgs[1];
                var age = int.Parse(commandArgs[2]);
                var kind = commandArgs[3];

                allPets.Add(name, new Pet(name, age, kind));
            }
            else if (entityType == "Clinic")
            {
                var name = commandArgs[1];
                var rooms = int.Parse(commandArgs[2]);

                try
                {
                    allClinics.Add(name, new Clinic(name, rooms));

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
