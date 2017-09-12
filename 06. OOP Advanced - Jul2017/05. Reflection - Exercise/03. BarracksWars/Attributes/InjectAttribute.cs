using System;

namespace _03BarracksFactory.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    class InjectAttribute : Attribute
    {
    }
}
