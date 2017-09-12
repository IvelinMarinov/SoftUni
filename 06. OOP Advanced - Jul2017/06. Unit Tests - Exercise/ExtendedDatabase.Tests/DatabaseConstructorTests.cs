using System;
using Extended_Database;
using NUnit.Framework;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    class DatabaseConstructorTests
    {
        [Test]
        public void ConsturctorTest15Persons()
        {
            // Arrange
            Person person1 = new Person(1, "person1");
            Person person2 = new Person(1, "person2");
            Person person3 = new Person(1, "person3");
            Person person4 = new Person(1, "person4");
            Person person5 = new Person(1, "person5");
            Person person6 = new Person(1, "person6");
            Person person7 = new Person(1, "person7");
            Person person8 = new Person(1, "person8");
            Person person9 = new Person(1, "person9");
            Person person10 = new Person(1, "person10");
            Person person11 = new Person(1, "person11");
            Person person12 = new Person(1, "person12");
            Person person13 = new Person(1, "person13");
            Person person14 = new Person(1, "person14");
            Person person15 = new Person(1, "person15");

            // Act
            Db db = new Db(person1, person2, person3, person4, person5, person6, person7, 
                person8, person9, person10, person11, person12, person13, person14, person15);

            // Assert
            Assert.AreEqual(15, db.CurrLenght);
        }

        [Test]
        public void ConsturctorTest16Persons()
        {
            // Arrange
            Person person1 = new Person(1, "person1");
            Person person2 = new Person(1, "person2");
            Person person3 = new Person(1, "person3");
            Person person4 = new Person(1, "person4");
            Person person5 = new Person(1, "person5");
            Person person6 = new Person(1, "person6");
            Person person7 = new Person(1, "person7");
            Person person8 = new Person(1, "person8");
            Person person9 = new Person(1, "person9");
            Person person10 = new Person(1, "person10");
            Person person11 = new Person(1, "person11");
            Person person12 = new Person(1, "person12");
            Person person13 = new Person(1, "person13");
            Person person14 = new Person(1, "person14");
            Person person15 = new Person(1, "person15");
            Person person16 = new Person(1, "person16");

            // Act
            Db db = new Db(person1, person2, person3, person4, person5, person6, person7,
                person8, person9, person10, person11, person12, person13, person14, person15, person16);

            // Assert
            Assert.AreEqual(16, db.CurrLenght);
        }

        [Test]
        public void ConsturctorTest17Persons()
        {
            // Arrange
            Person person1 = new Person(1, "person1");
            Person person2 = new Person(1, "person2");
            Person person3 = new Person(1, "person3");
            Person person4 = new Person(1, "person4");
            Person person5 = new Person(1, "person5");
            Person person6 = new Person(1, "person6");
            Person person7 = new Person(1, "person7");
            Person person8 = new Person(1, "person8");
            Person person9 = new Person(1, "person9");
            Person person10 = new Person(1, "person10");
            Person person11 = new Person(1, "person11");
            Person person12 = new Person(1, "person12");
            Person person13 = new Person(1, "person13");
            Person person14 = new Person(1, "person14");
            Person person15 = new Person(1, "person15");
            Person person16 = new Person(1, "person16");
            Person person17 = new Person(1, "person17");

            // Assert
            Assert.Throws<InvalidOperationException>(() => new Db(person1, person2, person3, person4, person5, person6,
                person7, person8,
                person9, person10, person11, person12, person13, person14, person15, person16, person17));
        }
    }
}
