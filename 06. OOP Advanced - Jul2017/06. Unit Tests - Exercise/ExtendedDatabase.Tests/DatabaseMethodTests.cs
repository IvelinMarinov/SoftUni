using System;
using Extended_Database;
using NUnit.Framework;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    class DatabaseMethodTests
    {
        [Test]
        public void AddPersonToDb()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            //Act
            Person person2 = new Person(2, "Test2");
            db.Add(person2);

            //Assert
            Assert.AreEqual(2, db.CurrLenght);
        }

        [Test]
        public void AddPersonToFullDb()
        {
            //Arrange
            Db db = new Db();

            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, "person" + i));
            }

            //Act
            Person person = new Person(17, "person17");

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(person));
        }

        [Test]
        public void RemovePersonGeneral()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            //Act
            db.Remove();

            //Assert
            Assert.AreEqual(0, db.CurrLenght);
        }

        [Test]
        public void RemovePersonFromEmptyDb()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            //Act
            db.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void AddPersonWithDuplicateId()
        {
            // Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Act
            Person personDuplId = new Person(1, "Test2");

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(personDuplId));
        }

        [Test]
        public void AddPersonWithDuplicateUsername()
        {
            // Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Act
            Person personDuplUsername = new Person(2, "Test");

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(personDuplUsername));
        }

        [Test]
        public void FindByIdGeneral()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Act
            Person result = db.FindById(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void FindByIdNotInCollection()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }

        [Test]
        public void FindByIdInvalidInput()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-5));
        }

        [Test]
        public void FindByUsernameGeneral()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Act
            Person result = db.FindByUsername("Test");

            // Assert
            Assert.AreEqual("Test", result.Username);
        }

        [Test]
        public void FindByUsernameNotInCollection()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Test2"));
        }

        [Test]
        public void FindByUsernameInvalidInput()
        {
            //Arrange
            Person person = new Person(1, "Test");
            Db db = new Db(person);

            // Assert
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(""));
        }
    }
}
