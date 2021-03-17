using abc.Facade.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Facade.Models
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void TestId()
        {
            var c = new Event
            {
                ID = 1
            };

            Assert.AreEqual(c.ID, 1);
        }

        [TestMethod]
        public void TestTitle()
        {
            var c = new Event
            {
                Title = "Test"
            };

            Assert.AreEqual(c.Title, "Test");
        }

        [TestMethod]
        public void TestDate()
        {
            var c = new Event
            {
                Date = DateTime.Now
            };

            Assert.IsInstanceOfType(c.Date, typeof(DateTime));
        }

        [TestMethod]
        public void TestLocation()
        {
            var c = new Event
            {
                Location = "Kadriorg"
            };

            Assert.AreEqual(c.Location, "Kadriorg");
        }

        [TestMethod]
        public void TestComment()
        {
            var c = new Event
            {
                Comment = "TestComment"
            };

            Assert.AreEqual(c.Comment, "TestComment");
        }
    }
}
