
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ExpressionBenchmark;
using ExpressionBenchmark.Executable;


public class Program
{
  [Benchmark(Description = "Reflection", Baseline = true)]
  public int Reflection()=> (int) typeof(Command)
    .GetMethod("Execute", BindingFlags.Public| BindingFlags.Instance)
    .Invoke(new Command(), null);
    
  [Benchmark(Description = "Reflection(cached)")]
  public int Cached()=>ReflectionCached.CallExecute(new Command());
  
  [Benchmark(Description = "Reflection(delegate)")]
  public int Delegate()=>ReflectionDelegate.CallExecute(new Command());
 
  [Benchmark(Description = "Expression")]
  public  int Expressions()=>ExpressionTrees.CallExecute(new Command());
  public  static void Main()=>BenchmarkRunner.Run<Program>();
}

 