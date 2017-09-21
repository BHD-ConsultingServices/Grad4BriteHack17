
namespace Hackathon.Tests.AdaptersTransactional
{
    using System;
    using StubData.Initiative;
    using KellermanSoftware.CompareNetObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AdapterTransactionalTests : TransactionalBase
    {
        public readonly CompareLogic Comparer;

        public AdapterTransactionalTests()
        {
            Comparer = new CompareLogic();
        }

        [TestMethod]
        public void CreateInitiativeAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var requestBuilder = new InitiativeBuilder().SbcaVolenteering();
            var mokAdapter = new InitiativeAdapter();

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
        public void UpdateInitiativeAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var requestBuilder = new InitiativeBuilder().SbcaVolenteering();
            var mokAdapter = new InitiativeAdapter();

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
        public void GetInitiativeAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var requestBuilder = new InitiativeBuilder().SbcaVolenteering();
            var mokAdapter = new InitiativeAdapter();

            // Act
            var response = mokAdapter.Get(Guid.NewGuid());
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed"); */
        }

        [TestMethod]
        public void GetAllInitiativesAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var mokAdapter = new InitiativeAdapter();

            // Act
            var response = mokAdapter.GetAllInitiatives();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 2, "Did not retrieve the expcted 2 stubbed intitatives"); */
        }

        [TestMethod]
        public void GetAllChallengesForInittiativeAdapter_Success()
        {
            throw new NotImplementedException();

            /*
            // Arrange
            var mokAdapter = new InitiativeAdapter();

            // Act
            var response = mokAdapter.GetAllChallenges(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 2, "Did not retrieve the expcted 2 stubbed challenges");
            */
        }

    }
}
