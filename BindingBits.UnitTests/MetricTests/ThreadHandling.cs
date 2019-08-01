using System;
using System.Collections.Generic;
using System.Threading;
using BindingBits.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BindingBits.UnitTests.MetricTests
{
    [TestClass]
    public class ThreadHandling
    {
        [TestMethod]
        public void DoesNotThrowAnyCollisionExceptions()
        {
            var threads = new List<Thread>();
            var myObservableObject = new TestObservableObject();
            var itemCount = 5000;
            for (var i = 0; i < itemCount; i++)
            {
                threads.Add(new Thread(() => SetValues(myObservableObject, itemCount - i)));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine(myObservableObject.StringPropertyNoBacking);

            Assert.IsTrue(true);
        }

        private void SetValues(TestObservableObject myObject, int sleepCount)
        {
            Thread.Sleep(sleepCount);
            for (var i = 0; i < 10; i++)
            {
                myObject.ObjectPropertyNoBacking = new SimpleObject
                {
                    Id = i,
                    Name = $"{i}",
                };
            }
        }
    }
}
