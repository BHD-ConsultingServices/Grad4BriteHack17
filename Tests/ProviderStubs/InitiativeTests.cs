
namespace Hackathon.Tests.ProviderStubs
{
    using Providers;
    using KellermanSoftware.CompareNetObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Initiative = StubData.Initiative;
    using System;
    using System.Linq;

    /// <summary>
    /// Summary description for ProviderTests
    /// </summary>
    [TestClass]
    public class InitiativeTests
    {
        public readonly CompareLogic Comparer;

        public InitiativeTests()
        {
            Comparer = new CompareLogic();
        }

        [TestMethod]
        public void CreateInitiativeProvider_Success()
        {
            // Arrange
            var requestBuilder = new Initiative.InitiativeBuilder().SbcaVolenteering();
            var mokAdapter = new Initiative.AdapterBuilder().AddCreateStub(requestBuilder.Build()).Build();
            var provider = new InitiativeProvider(mokAdapter);

            // Act
            var response = provider.Create(requestBuilder.BuildRequest());
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
        }

        [TestMethod]
        public void EditInitiativeProvider_Success()
        {
            // Arrange
            var requestBuilder = new Initiative.InitiativeBuilder().SbcaVolenteering().UpdateDescription("Custom description");
            var mokAdapter = new Initiative.AdapterBuilder().AddUpdateStub(requestBuilder.Build()).Build();
            var provider = new InitiativeProvider(mokAdapter);

            // Act
            var response = provider.Update(requestBuilder.Id,  requestBuilder.BuildRequest());
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
        }

        [TestMethod]
        public void GetInitiativeProvider_Success()
        {
            // Arrange
            var requestBuilder = new Initiative.InitiativeBuilder().SbcaVolenteering();
            var mokAdapter = new Initiative.AdapterBuilder().AddGetStub(requestBuilder.Build()).Build();
            var provider = new InitiativeProvider(mokAdapter);

            // Act
            var response = provider.Get(requestBuilder.Id);
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
        }

        [TestMethod]
        public void GetAllChallengesForInitiativeProvider_Success()
        {
            // Arrange
            var mokAdapter = new Initiative.AdapterBuilder().AddGetAllChallengesStub().Build();
            var provider = new InitiativeProvider(mokAdapter);

            // Act
            var response = provider.GetAllChallenges(Guid.NewGuid());
  
            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 2, "Did not return expected 2 challenges");
        }

        [TestMethod]
        public void GetAllInitiativesForInitiativeProvider_Success()
        {
            // Arrange
            var mokAdapter = new Initiative.AdapterBuilder().GetAllInitiatives().Build();
            var provider = new InitiativeProvider(mokAdapter);

            // Act
            var response = provider.GetAllInitiatives();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 2, "Did not return the expected 2 initiatives");
        }
    }
}
