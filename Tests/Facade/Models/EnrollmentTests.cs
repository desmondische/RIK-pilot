using abc.Facade.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Models
{
    [TestClass]
    public class EnrollmentTests
    {
        [TestMethod]
        public void TestId()
        {
            var c = new Enrollment
            {
                ID = 1
            };

            Assert.AreEqual(c.ID, 1);
        }

        [TestMethod]
        public void TestEventID()
        {
            var c = new Enrollment
            {
                EventID = 2
            };

            Assert.AreEqual(c.EventID, 2);
        }

        [TestMethod]
        public void TestParticipantID()
        {
            var c = new Enrollment
            {
                ParticipantID = 3
            };

            Assert.AreEqual(c.ParticipantID, 3);
        }
    }
}
