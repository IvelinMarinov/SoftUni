using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("cmp")]
    public class CompareFilesCommand : Command
    {
        [Inject]
        private IContentComparer judge;

        public CompareFilesCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 3)
            {
                string firstPath = this.Data[1];
                string secondPath = this.Data[2];

                this.judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}