using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | 
            BindingFlags.NonPublic | BindingFlags.Public);
        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields =
            classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = 
            classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        var x = classPublicMethods.Where(m => m.Name.StartsWith("get")).ToList();
        var y = classNonPublicMethods.Where(m => m.Name.StartsWith("set")).ToList();
        
        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo nonPublicMethod in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
        }

        foreach (MethodInfo publicMethod in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }


}