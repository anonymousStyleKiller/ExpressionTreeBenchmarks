using System.Linq.Expressions;

namespace ExpressionBenchmark.Operations;

public static class ExpressionCalc
{
    private static class Impl<T>
    {
        public static Func<T, T> Of { get; }

        static Impl()
        {
            var param = Expression.Parameter(typeof(T));
            var three = Expression.Convert(Expression.Constant(3), typeof(T));
            var four = Expression.Convert(Expression.Constant(4), typeof(T));
            var operation = Expression.Divide(Expression.Multiply(param, three), four);
            var lambda = Expression.Lambda<Func<T, T>>(operation, param);
            Of = lambda.Compile();
        }
    }


    public static T Of<T>(T x) => Impl<T>.Of(x);
}