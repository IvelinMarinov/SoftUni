using System;
using NUnit.Framework;
using Database_Problem;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void ConstructorTest15Numbers()
        {
            // Arrange & Act
            Db db = new Db(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            //Assert
            Assert.AreEqual(15, db.CurrLenght);
        }

        [Test]
        public void ConstructorTest16Numbers()
        {
            // Arrange & Act
            Db db = new Db(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            //Assert
            Assert.AreEqual(16, db.CurrLenght);
        }

        [Test]
        public void ConstructorTest17Numbers()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => new Db(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void ConstructorTestArrayLenght()
        {
            // Arrange & Act
            Db db = new Db(1, 2, 3, 4, 5, 6);

            //Assert
            Assert.AreEqual(16, db.Collection.Length);
        }

        [Test]
        public void AddsNumberGeneral()
        {
            //Arrange
            Db db = new Db(1, 2, 3, 4, 5, 6);

            //Act
            db.Add(7);

            //Assert
            Assert.AreEqual(7, db.CurrLenght);
        }

        [Test]
        public void AddsNumberAboveSizeLimit()
        {
            //Arrange
            Db db = new Db(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(17));
        }

        [Test]
        public void RemoveGeneral()
        {
            //Arrange
            Db db = new Db(1, 2, 3, 4, 5);

            //Act
            db.Remove();

            //Assert
            Assert.AreEqual(4, db.CurrLenght);
        }

        [Test]
        public void RemoveFromEmptyCollection()
        {
            //Arrange
            Db db = new Db(1);

            //Act
            db.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void FetchGeneral()
        {
            //Arrange
            Db db = new Db(1, 2, 3);

            //Act
            var result = db.Fetch();
            var expcted = new int[] {1, 2, 3};

            //Assert
            CollectionAssert.AreEqual(expcted, result);
        }
    }
}
