using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;

namespace BashSoft.IO.Commands
{
    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;
        
        public Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        public string[] Data
        {
            get { return this.data; }
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public string Input
        {
            get { return this.input; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public abstract void Execute();
    }
}