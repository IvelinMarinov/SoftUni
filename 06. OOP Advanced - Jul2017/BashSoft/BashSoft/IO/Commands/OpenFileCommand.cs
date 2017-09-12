﻿using BashSoft.Exceptions;
using System.Diagnostics;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("open")]
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];
                Process.Start(SessionsData.currentPath + "\\" + fileName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}