
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ExpressionBenchmark;
using ExpressionBenchmark.Executable;
using ExpressionBenchmark.Models;
using ExpressionBenchmark.Operations;


public class Program
{
    #region First Test

    // [Benchmark(Description = "Reflection", Baseline = true)]
    // public int Reflection()=> (int) typeof(Command)
    //     .GetMethod("Execute", BindingFlags.Public| BindingFlags.Instance)
    //     .Invoke(new Command(), null);
    //
    // [Benchmark(Description = "Reflection(cached)")]
    // public int Cached()=>ReflectionCached.CallExecute(new Command());
    //
    // [Benchmark(Description = "Reflection(delegate)")]
    // public int Delegate()=>ReflectionDelegate.CallExecute(new Command());
    //
    // [Benchmark(Description = "Expression")]
    // public  int Expressions()=>ExpressionTrees.CallExecute(new Command());

    #endregion

    #region Second Test

    [Benchmark(Description = "Base", Baseline = true)]
    [Arguments(13.37)]
    public double Static(double x) => (int)(3 * x / 4);  
    
    [Benchmark(Description = "Dynamic")]
    [Arguments(13.37)]
    public double Dynamic(double x) => DynamicCalc.Calc(x);  
    
    [Benchmark(Description = "Expression")]
    [Arguments(13.37)]
    public double Expression(double x) => ExpressionCalc.Of(x); 
   
    #endregion
    
    public  static void Main()=>BenchmarkRunner.Run<Program>();
}

 