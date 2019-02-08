using BindingBits.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BindingBits.Tests.MetricTests
{
    [TestClass]
    public class MemoryUsage
    {
        [TestMethod]
        public void MeasureMemoryUsed()
        {
            var memory1 = GC.GetTotalMemory(true);
            var list = new List<TestObservableObject>();
            for (var i = 0; i < 100; i++)
            {
                list.Add(new TestObservableObject
                {
                    BoolPropertyNoBacking = i % 2 == 0,
                    StringPropertyNoBacking = i % 2 == 0 ? $"Some value {i}" : null
                });
            }

            var memory2 = GC.GetTotalMemory(true);
            Console.WriteLine(memory2 - memory1);
            Console.WriteLine(list.Count);
        }
    }
}