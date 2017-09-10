using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    public class Hospital
    {
        public const int MaxBedPerDept = 20;
        
        public static void Main()
        {
            var hospital = new Dictionary<string, List<Patient>>();
            var patientsList = new List<Patient>();

            var input = Console.ReadLine();

            while (input != "Output")
            {
                var inputArgs = input
                    .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var department = inputArgs[0];
                var doctor = string.Concat(inputArgs[1], " ", inputArgs[2]);
                var patientName = inputArgs[3];

                if (!hospital.ContainsKey(department))
                {
                    hospital.Add(department, new List<Patient>());
                }

                var roomNum = CheckForAvailableBeds(department, hospital);

                if (roomNum != 0)
                {
                    var currPatient = new Patient()
                    {
                        Name = patientName,
                        Doctor = doctor,
                        Room = roomNum
                    };
                    hospital[department].Add(currPatient);
                    patientsList.Add(currPatient);
                }
                input = Console.ReadLine();
            }

            var output = Console.ReadLine();

            while (output != "End")
            {
                var outputArgs = output
                    .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (outputArgs.Length == 1)
                {
                    //Department
                    var department = outputArgs[0];
                    foreach (var patient in hospital[department])
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else if (outputArgs.Length == 2)
                {
                    int roomNum;
                    var parse = int.TryParse(outputArgs[1], out roomNum);

                    if (!parse)
                    {
                        //Doctor
                        var doctorName = string.Concat(outputArgs[0] + " " + outputArgs[1]);
                        var patients = patientsList
                            .Where(x => x.Doctor == doctorName)
                            .OrderBy(x => x.Name);

                        foreach (var patient in patients)
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        //Department + Room
                        var department = outputArgs[0];
                        var currRoomNum = int.Parse(outputArgs[1]);

                        var patients = hospital[department].Where(x => x.Room == currRoomNum).OrderBy(y => y.Name);

                        foreach (var patient in patients)
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }
                output = Console.ReadLine();
            }
        }

        private static int CheckForAvailableBeds(string department, Dictionary<string, List<Patient>> hospital)
        {
            for (int i = 1; i <= 20; i++)
            {
                var patientsInCurrRoom = hospital[department].Where(x => x.Room == i).ToList();
                if (patientsInCurrRoom.Count < 3)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
