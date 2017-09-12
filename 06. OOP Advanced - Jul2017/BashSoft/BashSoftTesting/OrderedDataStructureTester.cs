using System;
using System.Collections.Generic;
using BashSoft.Contracts;
using BashSoft.DataStructures;
using NUnit.Framework;

namespace BashSoftTesting
{
    [TestFixture]
    public class OrderedDataStructureTester
    {

        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void Setup()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(20, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(30, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestAddIncreasesSizee()
        {
            this.names.Add("Test");

            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("Test" + i);
            }

            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> listToBeAdded = new List<string> {"Test1", "Test2"};
            this.names.AddAll(listToBeAdded);

            Assert.AreEqual(2, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            this.names.Add("ccc");
            this.names.Add("bbb");
            this.names.Add("aaa");

            CollectionAssert.AreEqual(new List<string> {"aaa", "bbb", "ccc"}, this.names);
        }
    }
}
