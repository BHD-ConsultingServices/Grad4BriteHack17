
using System;

namespace Hackathon.Tests.ProviderStubs
{

    using KellermanSoftware.CompareNetObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StubData.Challenge;
    using BL.Providers;

    /// <summary>
    /// Summary description for ProviderTests
    /// </summary>
    [TestClass]
    public class ChallengeTests
    {
        public readonly CompareLogic Comparer;

        public ChallengeTests()
        {
            Comparer = new CompareLogic();
        }

        [TestMethod]
        public void CreateChallengeProvider_Success()
        {
            // Arrange
            var requestBuilder = new ChallengeBuilder().FavoratePassTime();
            var mokAdapter = new AdapterBuilder().AddCreateStub(requestBuilder.Build()).Build();
            var provider = new ChallengeProvider(mokAdapter);

            // Act
            var response = provider.Create(Guid.NewGuid(), requestBuilder.BuildRequest());
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
        }

        [TestMethod]
        public void EditChallengeProvider_Success()
        {
            // Arrange
            var requestBuilder = new ChallengeBuilder().FavoratePassTime().UpdateQuestion("Custom question");
            var mokAdapter = new AdapterBuilder().AddUpdateStub(requestBuilder.Build()).Build();
            var provider = new ChallengeProvider(mokAdapter);

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
        public void GetChallengeProvider_Success()
        {
            // Arrange
            var requestBuilder = new ChallengeBuilder().FavoratePassTime();
            var mokAdapter = new AdapterBuilder().AddGetStub(requestBuilder.Build()).Build();
            var provider = new ChallengeProvider(mokAdapter);

            // Act
            var response = provider.Get(requestBuilder.Id);
            var expected = requestBuilder.UpdateId(response.Id).Build();

            // Assert
            Assert.IsNotNull(response);
            var compareDetails = Comparer.Compare(expected, response);
            compareDetails.DisplayDifferences();
            Assert.IsTrue(compareDetails.AreEqual, "The initative comparison failed");
        }
    }
}
