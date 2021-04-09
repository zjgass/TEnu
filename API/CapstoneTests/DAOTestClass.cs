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
        protected Recipe TestRecipe1 { get; set; } = new Recipe();
        protected Recipe TestRecipe2 { get; set; } = new Recipe();
        protected Meal TestMeal1 { get; set; } = new Meal();
        protected Meal TestMeal2 { get; set; } = new Meal();
        protected Plan TestPlan1 { get; set; } = new Plan();
        protected Plan TestPlan2 { get; set; } = new Plan();

        [TestInitialize]
        public void SetUp()
        {
            Transaction = new TransactionScope();
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash("password");

            // Define TestUser1
            TestUser1.Username = "TestUser1";
            TestUser1.PasswordHash = hash.Password;
            TestUser1.Salt = hash.Salt;

            // Define TestUser2
            TestUser2.Username = "TestUser2";
            TestUser2.PasswordHash = hash.Password;
            TestUser2.Salt = hash.Salt;

            // Define TestRecipe1
            TestRecipe1.Name = "banana bread";
            TestRecipe1.Description = "my mother's recipe, the best!";
            TestRecipe1.IsPublic = true;
            TestRecipe1.Serves = 8;
            TestRecipe1.PrepTime = "20 min";
            TestRecipe1.CookTime = "45 min";
            TestRecipe1.TotalTime = "about an hour";
            //TestRecipe1.Ingredients = "[{\"name\": \"banana\", \"qty\": \"4 ea\"}, {\"name\": \"sugar\", \"qty\": \"3/4 cup\"}," +
            //        "{\"name\": \"chia seeds\", \"qty\": \"2tbs\"}, {\"name\": \"flour\", \"qty\": \"1 1/2 cups\"}, " +
            //        "{\"name\": \"coconut oil\", \"qty\": \"3tbs\"}, {\"name\": \"baking soda\", \"qty\": \"1tps\"}, " +
            //        "{\"name\": \"salt\", \"qty\": \"1tsp\"}, {\"name\": \"manderin oranges\", \"qty\": \"1 can\"}, " +
            //        "{\"name\": \"maraschino cherries\", \"qty\": \"to taste\"}," +
            //        "{\"name\": \"semi-sweet chocolate chips\", \"qty\": \"to taste\"}]";
            TestRecipe1.Utensils = "[\"mixing bowl\", \"mixer\", \"bread pan\", \"oven\"]";
            TestRecipe1.Instructions = "[\"thaw bananas\", \"mix all ingredients together\", \"pour in bread pan\", " +
                "\"bake in oven at 350F, check every half-hour\"]";
            TestRecipe1.ImgUrl = "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/4/13/0/GC_banana-bread_s4x3.jpg.rend.hgtvcom.826.620.suffix/1371592847747.jpeg";

            // Define TestRecipe2
            TestRecipe1.Name = "zucchini bread";
            TestRecipe1.Description = "christina's recipe, the best!";
            TestRecipe1.IsPublic = true;
            TestRecipe1.Serves = 8;
            TestRecipe1.PrepTime = "20 min";
            TestRecipe1.CookTime = "1 hour 20 min";
            TestRecipe1.TotalTime = "1 hour 40 min";
            //TestRecipe1.Ingredients = "[{\"name\": \"shredded zucchini\", \"qty\": \"3 cups\"}, {\"name\": \"brown sugar\", \"qty\": \"2 1/3 cup\"}," +
            //        "{\"name\": \"eggs\", \"qty\": \"4\"}, {\"name\": \"flour\", \"qty\": \"3 cups\"}, " +
            //        "{\"name\": \"canola oil\", \"qty\": \"1 1/2 cups\"}, {\"name\": \"baking soda\", \"qty\": \"1tsp\"}, " +
            //        "{\"name\": \"baking powder\", \"qty\": \"1 1/2tsp\"}, {\"name\": \"salt\", \"qty\": \"1 1/4t\"}, " +
            //        "{\"name\": \"melted unsweetened chocolate\", \"qty\": \"2oz\"}, {\"name\": \"semi-sweet chocolate chips\", \"qty\": \"1 cup\"} " +
            //        "{\"name\": \"allspice\", \"qty\": \"1/4tsp\"}, {\"name\": \"cinnamon\", \"qty\": \"1 1/2tsp\"}, " +
            //        "{\"name\": \"cloves\", \"qty\": \"1/4tsp\"}, {\"name\": \"chopped pecans\", \"qty\": \"1 cup\"}]";
            TestRecipe1.Utensils = "[\"mixing bowl\", \"mixer\", \"2 bread pan\", \"oven\"]";
            TestRecipe1.Instructions = "[\"Preheat oven to 350F\", \"Grease pans\", " +
                "\"In large bowl, combine flour, baking powder, baking soda, allspice, cinnamon, cloves, and salt. Set aside.\", " +
                "\"In large mixing bowl with mixer at medium speed, beat oil and sugar.\", " +
                "\"Add eggs to oil and sugar mixture, one at a time.\", " +
                "\"Gradually beat in melted chocolate.\", " +
                "\"Add dry ingredients and beat until smooth.\", " +
                "\"Fold in zucchini, chocolate chips, and pecans.\", " +
                "\"Pour into greased and floured pan.\", " +
                "\"Bake for 1 hour and 20 minuted or until toothpick comes out clean.\", " +
                "\"Cool in pan for 20 minutes before removing.\"]";
            TestRecipe1.ImgUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F1181288.jpg&w=1200&h=678&c=sc&poi=face&q=85";

            // Define TestMeal1
            TestMeal1.Name = "breakfast of champions";
            TestMeal1.UserId = TestUser1.UserId;

            // Define TestMeal2
            TestMeal1.Name = "second breakfast";
            TestMeal1.UserId = TestUser1.UserId;

            // Define TestPlan1
            TestPlan1.Name = "quick-bread only";
            TestPlan1.UserId = TestUser1.UserId;

            // Define TestPlan2
            TestPlan2.Name = "something other than quick-breads";
            TestPlan2.UserId = TestUser1.UserId;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Insert Users into the database
                    string sqlText = "insert into users (username, password_hash, salt) " +
                        "values (@username, @hash, @salt); select scope_Identity();";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
