using System.Linq.Expressions;
using System.Reflection;
using ExpressionBenchmark.Models;

namespace ExpressionBenchmark.Executable;

public static class ExpressionTrees
{
    public static MethodInfo? ExecuteMethod { get; } = typeof(Command).GetMethod("Execute",
        BindingFlags.Instance | BindingFlags.Public);

    public static Func<Command, int> Impl { get; }

    static ExpressionTrees()
    {
        var instance = Expression.Parameter(typeof(Command));
        var call = Expression.Call(instance, ExecuteMethod);
        Impl = Expression.Lambda<Func<Command, int>>(call, instance).Compile();
    }

    public static int CallExecute(Command command) => Impl(command);
}