using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Fagfredag.BenchmarkDotNet
{
	[RankColumn]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RPlotExporter]
	public class CollectionTypesBenchmarks
	{
		//[Params(10)]
		public int N = 100;

		public int searchTerm;

		private int minValue = 0, 
					maxValue = 10000;

		private List<int> list;
		private SortedList<int, int> sortedList;
		private HashSet<int> hashSet;
		private SortedSet<int> sortedSet;

		[GlobalSetup]
		public void Setup()
		{
			var i = 0;
			var random = new Random(42);

			list = new List<int>(N);
			sortedList = new SortedList<int, int>(N);
			hashSet = new HashSet<int>(N);
			sortedSet = new SortedSet<int>();

			while (i < N)
			{
				var r = random.Next(minValue, maxValue);
				list.Add(r);
				sortedList[r] = r;
				hashSet.Add(r);
				sortedSet.Add(r);
				i++;
			}
			searchTerm = random.Next(minValue, maxValue);
		}

		[GlobalCleanup]
		public void Cleanup()
		{
			// rm -rf /
		}

		[Benchmark]
		public bool ListContains()
		{
			return list.Contains(searchTerm);
		}

		[Benchmark]
		public bool SortedListContains()
		{
			return sortedList.ContainsValue(searchTerm);
		}

		[Benchmark]
		public bool HashSetContains()
		{
			return hashSet.Contains(searchTerm);
		}

		[Benchmark]
		public bool SortedSetContains()
		{
			return sortedSet.Contains(searchTerm);
		}
	}
}