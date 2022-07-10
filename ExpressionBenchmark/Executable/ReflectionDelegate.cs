using System.Reflection;
using ExpressionBenchmark.Models;

namespace ExpressionBenchmark.Executable;

public static class ReflectionDelegate
{
    public static MethodInfo? ExecuteMethod { get; } = typeof(Command)
        .GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance);

    public static Func<Command, int> Implementation { get; } = (Func<Command, int>)Delegate
        .CreateDelegate(typeof(Func<Command, int>), ExecuteMethod);

    public static int CallExecute(Command command) => Implementation(command);
}