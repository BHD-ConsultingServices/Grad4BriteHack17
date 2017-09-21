
namespace Hackathon.Tests.AdaptersTransactional
{
    using System;
    using StubData.Challenge;
    using KellermanSoftware.CompareNetObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChallegeTests : TransactionalBase
    {
        public readonly CompareLogic Comparer;

        public ChallegeTests()
        {
            Comparer = new CompareLogic();
        }

        [TestMethod]
        public void CreateChallengeAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var requestBuilder = new ChallengeBuilder().FavoratePassTime();
            var mokAdapter = new ChallengeAdapter();

            // Act
            var response = mokAdapter.Create(requestBuilder.Build());
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
            */
        }

        [TestMethod]
        public void UpdateChallengeAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var requestBuilder = new ChallengeBuilder().FavoratePassTime();
            var mokAdapter = new ChallengeAdapter();

            // Act
            var response = mokAdapter.Update(Guid.NewGuid(), requestBuilder.Build());
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
            */
        }

        [TestMethod]
        public void GetChallengeAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var requestBuilder = new ChallengeBuilder().FavoratePassTime();
            var mokAdapter = new ChallengeAdapter();

            // Act
            var response = mokAdapter.Get(Guid.NewGuid());
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
            */
        }
    }
}
