using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CatchTheMouse.Lib.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        [DataRow(10000, 60, 10000)]
        [DataRow(50, 30, 50)]
        [DataRow(-1200, -3000, 0)]
        public void ChangeHighScore_SeeIfHighScoreChanges_ChangeCurrentHighScoreIfTheNewOneIsHigher(int newScoreHigher, int newScoreLower, int expectedHighScore)
        {
            //Arrange
            User user = new User("John", "Doe", DateTime.Now, int.MinValue);
            
            // Act
            int updatedScore=user.ChangeHighScore(newScoreHigher);
            updatedScore=user.ChangeHighScore(newScoreLower);
            // Assert
            Assert.AreEqual(expectedHighScore,updatedScore);
        }
        [TestMethod]
       
        public void CompareTo_SortsTwoUserbasedOnTheHighScoreThenByName_ReturnsASortedList()
        {
            // Arrange
            List<User> users = new List<User>
            {
                new User("John", "Doe", DateTime.Now, 500),
                new User("Alice", "Smith", DateTime.Now, 600),
                new User("Bob", "Brown", DateTime.Now, 1500),
                new User("Charlie", "Davis", DateTime.Now, 1000)
            };

            //Act
            users.Sort();
            // Assert
            Assert.AreEqual("Bob", users[0].FirstName);
        }
    }
}
