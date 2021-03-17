using abc.Facade.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Facade.Models
{
    [TestClass]
    public class DbInitializerTests
    {
        [TestMethod]
        public void TestId()
        {
            var p = new Participant
            {
                ID = 10
            };

            Assert.AreEqual(p.ID, 10);
        }

        [TestMethod]
        public void TestFirstName()
        {
            var p = new Participant
            {
                FirstName = "Mark"
            };

            Assert.AreEqual(p.FirstName, "Mark");
        }

        [TestMethod]
        public void TestLastName()
        {
            var p = new Participant
            {
                LastName = "Zuckerberg"
            };

            Assert.AreEqual(p.LastName, "Zuckerberg");
        }

        [TestMethod]
        public void TestFullName()
        {
            var p = new Participant
            {
                FirstName = "Mark",
                LastName = "Zuckerberg"
            };

            var expected = "Mark Zuckerberg";
            var actual = p.FullName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPersonalCode()
        {
            var p = new Participant
            {
                PersonalCode = "39902180253"
            };

            Assert.AreEqual(p.PersonalCode, "39902180253");
        }

        [TestMethod]
        public void TestLegalName()
        {
            var p = new Participant
            {
                LegalName = "CINAMON"
            };

            Assert.AreEqual(p.LegalName, "CINAMON");
        }

        [TestMethod]
        public void TestParticipantQuantity()
        {
            var p = new Participant
            {
                ParticipantsQty = 1
            };

            Assert.AreEqual(p.ParticipantsQty, 1);
        }


        [TestMethod]
        public void TestComment()
        {
            var p = new Participant
            {
                Comment = "TestComment"
            };

            Assert.AreEqual(p.Comment, "TestComment");
        }
    }
}
