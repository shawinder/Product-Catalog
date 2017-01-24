using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductCatalog.Website.Tests
{
    #region Includes

    using System.Data.Entity;
    using Data;
    
    #endregion

    [TestClass]
    public class DataTest
    {
        private CatalogContext  _dbcontext;

        [TestInitialize]
        public void TestSetup()
        {
            _dbcontext = new CatalogContext();
        }

        [TestMethod]
        public void CreateAndSeedDatabaseTest()
        {
            var dbInitializer = new CatalogInitializer();
            Database.SetInitializer(dbInitializer);

            dbInitializer.InitializeDatabase(_dbcontext);
        }
    }
}
