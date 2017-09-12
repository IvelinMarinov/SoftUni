using BashSoft.Exceptions;
using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("cdRel")]
    public class ChangeRelativePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string relPath = this.Data[1];
                this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}