using System.Reflection;

namespace ExpressionBenchmark.Executable;

public static class ReflectionCached
{
    public static MethodInfo? ExecuteMethod { get; } = typeof(Command)
        .GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance);

    public static int CallExecute(Command command) =>
        (int)ExecuteMethod.Invoke(command, null);
}