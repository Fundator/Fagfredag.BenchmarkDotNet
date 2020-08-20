using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Fagfredag.BenchmarkDotNet
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			BenchmarkRunner.Run<CollectionTypesBenchmarks>();
		}
	}
}