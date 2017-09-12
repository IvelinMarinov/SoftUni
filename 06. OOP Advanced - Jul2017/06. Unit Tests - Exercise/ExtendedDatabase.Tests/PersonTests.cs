using NUnit.Framework;
using Extended_Database;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void ConstructorTestId()
        {
            //Arrange & Act
            Person person = new Person(123, "Gosho");

            //Act
            Assert.AreEqual(123, person.Id);
        }

        [Test]
        public void ConstructorTestUsername()
        {
            //Arrange & Act
            Person person = new Person(123, "Gosho");

            //Act
            Assert.AreEqual("Gosho", person.Username);
        }
    }
}
