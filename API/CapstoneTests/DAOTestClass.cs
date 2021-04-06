using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Transactions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace CapstoneTests
{
    [TestClass]
    class DAOTestClass
    {
        public static IConfiguration Configuration
        {
            get
            {
                var config = new ConfigurationBuilder()
                .AddJsonFile("appsetting.test.json")
                .Build();
                return config;
            }
        }

        protected TransactionScope Transaction { get; set; }
        protected string connectionString = Configuration.GetConnectionString("Project");

        protected User TestUser1 { get; set; } = new User();
        protected User TestUser2 { get; set; } = new User();
        protected 

    }
}
