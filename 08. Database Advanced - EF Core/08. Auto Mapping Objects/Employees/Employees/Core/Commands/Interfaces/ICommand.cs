using System.Collections.Generic;

namespace Employees.App.Core.Commands.Interfaces
{
    public interface ICommand
    {
        string Execute(IList<string> data);
    }
}
