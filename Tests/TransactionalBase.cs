
namespace Hackathon.Tests
{
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class TransactionalBase
    {
        private static bool _isInitialized;
        private TransactionScope _scope;

        public void InitializeGlobal()
        {
            if (_isInitialized) return;

            // TODO: Initialize local db only once per run

            _isInitialized = true;
        }

        [TestInitialize]
        public void TestInitialization()
        {
            InitializeGlobal();

            this._scope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        [TestCleanup]
        public void TestComplete()
        {
            this._scope.Dispose();
        }
    }
}
