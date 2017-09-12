using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate
{
    IList<ISoldier> PrivatesInCommand { get; }
}