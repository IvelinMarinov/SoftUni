using BashSoft.Contracts;
using BashSoft.IO.Commands;
using System;
using System.Linq;
using System.Reflection;
using BashSoft.Attributes;

namespace BashSoft
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] ParametersForConstruction = new object[]
            {
                input,
                data
            };

            Type typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(t => t.GetCustomAttributes(typeof(AliasAttribute))
                    .Where(atr => atr.Equals(command))
                    .ToArray()
                    .Length > 0);

            Type typeOfCommandInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, ParametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] fieldsOfInterpreter = typeOfCommandInterpreter
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute attr = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                
                if (attr != null)
                {
                    bool xyz = fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType);
                    var y = fieldsOfInterpreter.Last().FieldType;
                    var z = fieldOfCommand.FieldType;
                    bool a = y == z;

                    if (fieldsOfInterpreter.Any(x => x.FieldType.Name == fieldOfCommand.FieldType.Name))
                    {
                        object valueToBeInjectedd = fieldsOfInterpreter
                            .First(x => x.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this);
                        fieldOfCommand.SetValue(exe, valueToBeInjectedd);
                    }
                }
            }

            return exe;
        }
    }
}