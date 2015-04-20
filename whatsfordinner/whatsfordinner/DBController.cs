using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using Microsoft.Win32.SafeHandles;
using System.Configuration;

namespace whatsfordinner {
    public class DBController {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private NpgsqlConnection conn;

        private static string dbHost = "localhost";
        private static string dbName = "testDB";
        private static string dbUser = "casper";
        private static string dbPass = "1234";

        public DBController() {
            string connstring = String.Format(
                "Server={0};User Id={1};Password={2};Database={3};Encoding=Unicode;",
                dbHost, dbUser, dbPass, dbName);
            conn = new NpgsqlConnection(connstring);
            //
            conn.Open();
        }

        public void Close() {
            conn.Close();
        }

        private DataRowCollection Query(string sql) {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            return dt.Rows;
        }

        private int NonQuery(NpgsqlCommand command, string table) {
            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows == 0) {
                return -1;
            } else {
                return affectedRows;
            }
        }
        
        #region GetAll of the Entities
        
        public List<Account> GetAllAccounts() {
            string sql = String.Format("SELECT * FROM accounts");
            DataRowCollection res = Query(sql);
            List<Account> allAccounts = new List<Account>();
            if (res.Count >= 1) {
                foreach (DataRow account in res) {
                    allAccounts.Add(new Account(account));
                }
                return allAccounts;
            } else {
                return allAccounts;
            }
        }

        public List<Comment> GetAllComments() {
            string sql = String.Format("SELECT * FROM comments");
            DataRowCollection res = Query(sql);
            List<Comment> allComments = new List<Comment>();
            if (res.Count >= 1) {
                foreach (DataRow comment in res) {
                    allComments.Add(new Comment(comment));
                }
                return allComments;
            } else {
                return allComments;
            }
        }

        public List<Ingredient> GetAllIngredients() {
            string sql = String.Format("SELECT * FROM ingredients");
            DataRowCollection res = Query(sql);
            List<Ingredient> allIngredients = new List<Ingredient>();
            if (res.Count >= 1) {
                foreach (DataRow ingredient in res) {
                    allIngredients.Add(new Ingredient(ingredient));
                }

                return allIngredients;
            } else {
                return allIngredients;
            }
        }

        public List<Recipe> GetAllRecipes() {
            string sql = String.Format("SELECT * FROM recipes");
            DataRowCollection res = Query(sql);
            List<Recipe> allRecipes = new List<Recipe>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Recipe recipe = new Recipe(datarow);
                    allRecipes.Add(recipe);
                }
                return allRecipes;
            } else {
                return allRecipes;
            }
        }

        public List<Retailer> GetAllRetailers() {
            string sql = String.Format("SELECT * FROM retailers");
            DataRowCollection res = Query(sql);
            List<Retailer> allRetailers = new List<Retailer>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Retailer retailer = new Retailer(datarow);
                    allRetailers.Add(retailer);
                }
                return allRetailers;
            } else {
                return allRetailers;
            }
        }
        #endregion

        #region Get all of the Relationships

        public List<Favorises> GetAllFavorises() {
            string sql = String.Format("SELECT * FROM favorises");
            DataRowCollection res = Query(sql);
            List<Favorises> allFavorises = new List<Favorises>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Favorises favorises = new Favorises(datarow);
                    allFavorises.Add(favorises);
                }
                return allFavorises;
            } else {
                return allFavorises;
            }
        }

        public List<HasEaten> GetAllHasEaten() {
            string sql = String.Format("SELECT * FROM haseaten");
            DataRowCollection res = Query(sql);
            List<HasEaten> allHasEaten = new List<HasEaten>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    HasEaten hasEaten = new HasEaten(datarow);
                    allHasEaten.Add(hasEaten);
                }
                return allHasEaten;
            } else {
                return allHasEaten;
            }
        }

        public List<IngredientIn> GetAllIngredientIn() {
            string sql = String.Format("SELECT * FROM ingredientin");
            DataRowCollection res = Query(sql);
            List<IngredientIn> allIngredientIn = new List<IngredientIn>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    IngredientIn ingredientIn = new IngredientIn(datarow);
                    allIngredientIn.Add(ingredientIn);
                }
                return allIngredientIn;
            } else {
                return allIngredientIn;
            }
        }

        public List<Offers> GetAllOffers() {
            string sql = String.Format("SELECT * FROM offers");
            DataRowCollection res = Query(sql);
            List<Offers> allOffers = new List<Offers>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Offers offers = new Offers(datarow);
                    allOffers.Add(offers);
                }
                return allOffers;
            } else {
                return allOffers;
            }
        }

        public List<Pictures> GetAllPictures() {
            string sql = String.Format("SELECT * FROM pictures");
            DataRowCollection res = Query(sql);
            List<Pictures> allPictures = new List<Pictures>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Pictures pictures = new Pictures(datarow);
                    allPictures.Add(pictures);
                }
                return allPictures;
            } else {
                return allPictures;
            }
        }
        #endregion

        #region All Entities methods for adding a single instance to the DB

        public int AddAccount(Account accountToInsert) {
            string sql = "INSERT INTO accounts(email, password, alias, settings, preferences) VALUES (@email, @password, @alias, @settings, @preferences)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@email", accountToInsert.GetOrSetEmail);
            command.Parameters.AddWithValue("@password", accountToInsert.GetOrSetPassword);
            command.Parameters.AddWithValue("@alias", accountToInsert.GetOrSetAlias);
            command.Parameters.AddWithValue("@settings", accountToInsert.GetOrSetSettings);
            command.Parameters.AddWithValue("@preferences", accountToInsert.GetOrSetPreferences);

            return NonQuery(command, "accounts");
        }

        public int AddComment(Comment commentToInsert) {
            string sql = "INSERT INTO comments(accountid, recipeid, text) VALUES (@accountid, @recipeid, @text)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", commentToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", commentToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@text", commentToInsert.GetOrSetText);

            return NonQuery(command, "comments");
        }

        public int AddIngredient(Ingredient ingredientToInsert) {
            string sql = "INSERT INTO ingredients(name, measurementtype, measure, price, organic, fat, fresh) VALUES (@name, @measurementtype, @measure, @price, @organic, @fat, @fresh)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@name", ingredientToInsert.GetOrSetName);
            command.Parameters.AddWithValue("@measurementtype", ingredientToInsert.GetOrSetMeasurementType);
            command.Parameters.AddWithValue("@measure", ingredientToInsert.GetOrSetMeasure);
            command.Parameters.AddWithValue("@price", ingredientToInsert.GetOrSetPrice);
            command.Parameters.AddWithValue("@organic", ingredientToInsert.GetOrSetOrganic);
            command.Parameters.AddWithValue("@fat", ingredientToInsert.GetOrSetFat);
            command.Parameters.AddWithValue("@fresh", ingredientToInsert.GetOrSetFresh);
            command.Parameters.AddWithValue("@tags", ingredientToInsert.GetOrSetTags);

            return NonQuery(command, "ingredients");
        }

        public int AddRecipe(Recipe recipeToInsert) {
            string sql = "INSERT INTO recipes(accountid, name, description, numberofservings, rating) VALUES (@accountid, @name, @description, @numberofservings, @rating)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", recipeToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@name", recipeToInsert.GetOrSetName);
            command.Parameters.AddWithValue("@description", recipeToInsert.GetOrSetDescription);
            command.Parameters.AddWithValue("@numberofservings", recipeToInsert.GetOrSetNumberOfServings);
            command.Parameters.AddWithValue("@rating", recipeToInsert.GetOrSetRating);


            return NonQuery(command, "recipes");
        }

        public int AddRetailer(Retailer retailerToInsert) {
            string sql = "INSERT INTO retailers(latitude, longitude, companyname, description, openinghours) VALUES (@latitude, @longitude, @companyname, @description, @openinghours) RETURNING retailerid";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@latitude", retailerToInsert.GetOrSetLatitude);
            command.Parameters.AddWithValue("@longitude", retailerToInsert.GetOrSetLongitude);
            command.Parameters.AddWithValue("@companyname", retailerToInsert.GetOrSetCompanyName);
            command.Parameters.AddWithValue("@description", retailerToInsert.GetOrSetDescription);
            command.Parameters.AddWithValue("@openinghours", retailerToInsert.GetOrSetOpeningHours);

            return Int32.Parse(command.ExecuteScalar().ToString());
            //return NonQuery(command, "retailers");
        }
        #endregion

        #region All Relationship methods for adding a single instance to the DB
        public int AddFavorises(Favorises favorisesToInsert) {
            string sql = "INSERT INTO favorises(accountid, recipeid) VALUES (@accountid, @recipeid)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", favorisesToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", favorisesToInsert.GetOrSetRecipeId);

            return NonQuery(command, "favorises");
        }

        public int AddHasEaten(HasEaten hasEatenToInsert) {
            string sql = "INSERT INTO haseaten(accountid, recipeid, eatenat, rating) VALUES (@accountid, @recipeid, @eatenat, @rating)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", hasEatenToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", hasEatenToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@eatenat", hasEatenToInsert.GetOrSetEatenAt);
            command.Parameters.AddWithValue("@rating", hasEatenToInsert.GetOrSetRating);

            return NonQuery(command, "haseaten");
        }

        public int AddIngredientIn(IngredientIn ingredientInToInsert) {
            string sql = "INSERT INTO ingredientin(ingredientid, recipeid, amount) VALUES (@ingredientid, @recipeid, @amount)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@ingredientid", ingredientInToInsert.GetOrSetIngredientId);
            command.Parameters.AddWithValue("@recipeid", ingredientInToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@amount", ingredientInToInsert.GetOrSetAmount);

            return NonQuery(command, "ingredientin");
        }

        public int AddOffers(Offers offersToInsert) {
            string sql = "INSERT INTO offers(retailerid, ingredientid, offerfrom, offerto, normalprice, onsaleprice, krsaving, percentagesavingretailer, percentagesavinggeneral) "
                            + "VALUES (@retailerid, @ingredientid, @offerfrom, @offerto, @normalprice, @onsaleprice, @krsaving, @percentagesavingretailer, @percentagesavinggeneral)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@retailerid", offersToInsert.GetOrSetRetailerId);
            command.Parameters.AddWithValue("@ingredientid", offersToInsert.GetOrSetIngredientId);
            command.Parameters.AddWithValue("@offerfrom", offersToInsert.GetOrSetOfferFrom);
            command.Parameters.AddWithValue("@offerto", offersToInsert.GetOrSetOfferTo);
            command.Parameters.AddWithValue("@normalprice", offersToInsert.GetOrSetNormalPrice);
            command.Parameters.AddWithValue("@onsaleprice", offersToInsert.GetOrSetOnSalePrice);
            command.Parameters.AddWithValue("@krsaving", offersToInsert.GetOrSetKrSaving);
            command.Parameters.AddWithValue("@percentagesavingretailer", offersToInsert.GetOrSetPercentageSavingRetailer);
            command.Parameters.AddWithValue("@percentagesavinggeneral", offersToInsert.GetOrSetPercentageSavingGeneral);

            return NonQuery(command, "offers");
        }

        public int AddPictures(Pictures picturesToInsert) {
            string sql = "INSERT INTO pictures(accountid, recipeid, picturepath, creationdate) VALUES (@accountid, @recipeid, @picturepath, @creationdate)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", picturesToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", picturesToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@picturepath", picturesToInsert.GetOrSetPicturePath);
            command.Parameters.AddWithValue("@creationdate", picturesToInsert.GetOrSetCreationDate);

            return NonQuery(command, "pictures");
        }
        #endregion

        #region All Entities GetById

        public Account GetAccountById(int accountId) {
            string sql = String.Format("SELECT * FROM accounts WHERE accountid = '{0}'", accountId);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Account(res[0]);
            } else {
                return null;
            }
        }

        public Comment GetCommentById(int commentId) {
            string sql = String.Format("SELECT * FROM comments WHERE commentid = '{0}'", commentId);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Comment(res[0]);
            } else {
                return null;
            }
        }

        public Ingredient GetIngredientById(int ingredientId) {
            string sql = String.Format("SELECT * FROM ingredients WHERE ingredientid = '{0}'", ingredientId);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Ingredient(res[0]);
            } else {
                return null;
            }
        }

        public Recipe GetRecipeById(int recipeId) {
            string sql = String.Format("SELECT * FROM recipes WHERE recipeid = '{0}'", recipeId);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Recipe(res[0]);
            } else {
                return null;
            }
        }

        public Retailer GetRetailerById(int retailerId) {
            string sql = String.Format("SELECT * FROM retailers WHERE retailerid = '{0}'", retailerId);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Retailer(res[0]);
            } else {
                return null;
            }
        }
        #endregion

        #region Relationship queries, get by ids

        public List<Favorises> GetFavorisesByAccountId(int accountId) {
            string sql = String.Format("SELECT * FROM favorises WHERE accountid = '{0}'", accountId);
            DataRowCollection res = Query(sql);
            List<Favorises> allFavorisesFromAccountId = new List<Favorises>();
            if (res.Count >= 1) {
                foreach (DataRow favorises in res) {
                    allFavorisesFromAccountId.Add(new Favorises(favorises));
                }
                return allFavorisesFromAccountId;
            } else {
                return allFavorisesFromAccountId;
            }
        }

        public List<Favorises> GetFavorisesByRecipeId(int recipeId) {
            string sql = String.Format("SELECT * FROM favorises WHERE recipeid = '{0}'", recipeId);
            DataRowCollection res = Query(sql);
            List<Favorises> allFavorisesFromRecipeId = new List<Favorises>();
            if (res.Count >= 1) {
                foreach (DataRow favorises in res) {
                    allFavorisesFromRecipeId.Add(new Favorises(favorises));
                }
                return allFavorisesFromRecipeId;
            } else {
                return allFavorisesFromRecipeId;
            }
        }

        public List<Recipe> GetFavorisedRecipesByAccountId(int accountId) {
            string sql = String.Format("SELECT recipes.recipeid, recipes.accountid, recipes.name, recipes.description, recipes.creationdate, recipes.numberofservings, recipes.tags, recipes.rating "
                                        + "FROM (SELECT favorises.recipeid FROM favorises WHERE accountid = '{0}') AS favs, recipes WHERE favs.recipeid = recipes.recipeid", accountId);
            DataRowCollection res = Query(sql);
            List<Recipe> allFavorisedRecipesFromAccountId = new List<Recipe>();
            if (res.Count >= 1) {
                foreach (DataRow recipe in res) {
                    allFavorisedRecipesFromAccountId.Add(new Recipe(recipe));
                }
                return allFavorisedRecipesFromAccountId;
            } else {
                return allFavorisedRecipesFromAccountId;
            }
        }

        public List<IngredientIn> GetIngredientInsByIngredientId(int ingredientId) {
            string sql = String.Format("SELECT * FROM ingredientin WHERE ingredientid = '{0}'", ingredientId);
            DataRowCollection res = Query(sql);
            List<IngredientIn> allIngredientsInsFromIngredientId = new List<IngredientIn>();
            if (res.Count >= 1) {
                foreach (DataRow ingredientIn in res) {
                    allIngredientsInsFromIngredientId.Add(new IngredientIn(ingredientIn));
                }
                return allIngredientsInsFromIngredientId;
            } else {
                return allIngredientsInsFromIngredientId;
            }
        }

        public List<IngredientIn> GetIngredientInsByRecipeId(int recipeId) {
            string sql = String.Format("SELECT * FROM ingredientin WHERE recipeid = '{0}'", recipeId);
            DataRowCollection res = Query(sql);
            List<IngredientIn> allIngredientsInsFromRecipeId = new List<IngredientIn>();
            if (res.Count >= 1) {
                foreach (DataRow ingredientIn in res) {
                    allIngredientsInsFromRecipeId.Add(new IngredientIn(ingredientIn));
                }
                return allIngredientsInsFromRecipeId;
            } else {
                return allIngredientsInsFromRecipeId;
            }
        }

        public List<Pictures> GetPicturesByRecipeId(int recipeId) {
            string sql = String.Format("SELECT * FROM pictures WHERE recipeid = '{0}'", recipeId);
            DataRowCollection res = Query(sql);
            List<Pictures> allPicturesFromRecipeId = new List<Pictures>();
            if (res.Count >= 1) {
                foreach (DataRow pictures in res) {
                    allPicturesFromRecipeId.Add(new Pictures(pictures));
                }
                return allPicturesFromRecipeId;
            } else {
                return allPicturesFromRecipeId;
            }
        }

        public List<Offers> GetOfferByRetailerId(int retailerId) {
            string sql = String.Format("SELECT * FROM offers WHERE retailerid = '{0}'", retailerId);
            DataRowCollection res = Query(sql);
            List<Offers> allOffersFromRetailerId = new List<Offers>();
            if (res.Count >= 1) {
                foreach (DataRow offers in res) {
                    allOffersFromRetailerId.Add(new Offers(offers));
                }
                return allOffersFromRetailerId;
            } else {
                return allOffersFromRetailerId;
            }
        }

        public List<Offers> GetOfferByIngredientId(int ingredientId) {
            string sql = String.Format("SELECT * FROM offers WHERE ingredientid = '{0}'", ingredientId);
            DataRowCollection res = Query(sql);
            List<Offers> allOffersFromIngredientId = new List<Offers>();
            if (res.Count >= 1) {
                foreach (DataRow offers in res) {
                    allOffersFromIngredientId.Add(new Offers(offers));
                }
                return allOffersFromIngredientId;
            } else {
                return allOffersFromIngredientId;
            }
        }
        #endregion

        #region Delete entities by id

        public bool DeleteAccountById(int accountId) {
            string sql = String.Format("DELETE FROM accounts WHERE accountid = '{0}'", accountId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "accounts");

            return affectedRows >= 1 ? true : false;
        }

        public bool DeleteCommentById(int commentId) {
            string sql = String.Format("DELETE FROM comments WHERE commentid = '{0}'", commentId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "comments");

            return affectedRows >= 1 ? true : false;
        }

        public bool DeleteIngredientById(int ingredientId) {
            string sql = String.Format("DELETE FROM ingredients WHERE ingredientid = '{0}'", ingredientId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "ingredients");

            return affectedRows >= 1 ? true : false;
        }

        public bool DeleteRecipeById(int recipeId) {
            string sql = String.Format("DELETE FROM recipes WHERE recipeid = '{0}'", recipeId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "recipes");

            return affectedRows >= 1 ? true : false;
        }

        public bool DeleteRetailerById(int retailerId) {
            string sql = String.Format("DELETE FROM retailers WHERE retailerid = '{0}'", retailerId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "retailers");

            return affectedRows >= 1 ? true : false;
        }
        #endregion

        #region Delete relationships by ids

        public bool DeleteFavorisesByAccountIdAndRecipeId(int accountId, int recipeId) {
            string sql = String.Format("DELETE FROM favorises WHERE accountid = '{0}' AND recipeid = '{1}'", accountId, recipeId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "favorises");

            return affectedRows >= 1 ? true : false;
        }

        public bool DeleteIngredientInByIngredientIdAndRecipeId(int ingredientId, int recipeId) {
            string sql = String.Format("DELETE FROM ingredientin WHERE ingredientid = '{0}' AND recipeid = '{1}'", ingredientId, recipeId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "ingredientin");

            return affectedRows >= 1 ? true : false;
        }

        public bool DeleteOffersByRetailerIdAndIngredientId(int retailerId, int ingredientId) {
            string sql = String.Format("DELETE FROM offers WHERE retailerid = '{0}' AND ingredientid = '{1}'", retailerId, ingredientId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "offers");

            return affectedRows >= 1 ? true : false;
        }

        public bool DeletePictursByAccountIdAndRecipeId(int accountId, int recipeId) {
            string sql = String.Format("DELETE FROM pictures WHERE accountid = '{0}' AND recipeid = '{1}'", accountId, recipeId);
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int affectedRows = NonQuery(command, "pictures");

            return affectedRows >= 1 ? true : false;
        }


        #endregion

        #region Special queries / entity specific queries
        //

        public Account GetAccountByEmail(string accountEmail) {
            string sql = String.Format("SELECT * FROM accounts WHERE email = '{0}'", accountEmail);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Account(res[0]);
            } else {
                return null;
            }
        }

        public List<Comment> GetCommentsByRecipeId(int recipeId) {
            string sql = String.Format("SELECT * FROM comments WHERE recipeid = '{0}'", recipeId);
            DataRowCollection res = Query(sql);
            List<Comment> allCommentsFromRecipeId = new List<Comment>();
            if (res.Count >= 1) {
                foreach (DataRow comment in res) {
                    allCommentsFromRecipeId.Add(new Comment(comment));
                }
                return allCommentsFromRecipeId;
            } else {
                return allCommentsFromRecipeId;
            }
        }

        public Ingredient GetIngredientByName(string ingredientName) {
            string sql = String.Format("SELECT * FROM ingredients WHERE name = '{0}'", ingredientName);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Ingredient(res[0]);
            } else {
                return null;
            }
        }

        public List<Recipe> GetRecipesByAccountId(int accountId) {
            string sql = String.Format("SELECT * FROM recipes WHERE accountid = '{0}'", accountId);
            DataRowCollection res = Query(sql);
            List<Recipe> allRecipesFromAccountId = new List<Recipe>();
            if (res.Count >= 1) {
                foreach (DataRow recipe in res) {
                    allRecipesFromAccountId.Add(new Recipe(recipe));
                }
                return allRecipesFromAccountId;
            } else {
                return allRecipesFromAccountId;
            }
        }

        public List<Ingredient> GetIngredientsByRecipeId(int recipeId) {
            string sql = String.Format("SELECT ingredients.ingredientid, ingredients.name, ingredients.measurementtype, ingredients.measure, ingredients.price, ingredients.tags " +
                                        "FROM ingredients, ingredientin " +
                                        "WHERE ingredientin.ingredientid = ingredients.ingredientid AND ingredientin.recipeid = '{0}'", recipeId);
            DataRowCollection res = Query(sql);
            List<Ingredient> allIngredientsFromRecipeId = new List<Ingredient>();
            if (res.Count >= 1) {
                foreach (DataRow ingredient in res) {
                    allIngredientsFromRecipeId.Add(new Ingredient(ingredient));
                }
                return allIngredientsFromRecipeId;
            } else {
                return allIngredientsFromRecipeId;
            }
        }

        public List<Recipe> GetRecipesByIngredientId(int ingredientId) {
            string sql = String.Format("SELECT recipes.recipeid, recipes.accountid, recipes.name, recipes.description, "
                + "recipes.creationdate, recipes.numberofservings, recipes.tags, recipes.rating "
                + "FROM recipes, ingredientin WHERE ingredientid = '{0}'", ingredientId);
            DataRowCollection res = Query(sql);
            List<Recipe> allRecipesFromIngredientId = new List<Recipe>();
            if (res.Count >= 1) {
                foreach (DataRow recipe in res) {
                    allRecipesFromIngredientId.Add(new Recipe(recipe));
                }
                return allRecipesFromIngredientId;
            } else {
                return allRecipesFromIngredientId;
            }
        }

        public RecipeWithIngredients GetRecipeByIdWithIngredients(int recipeId) {
            RecipeWithIngredients rec = new RecipeWithIngredients();
            rec.GetOrSetRecipe = GetRecipeById(recipeId);
            rec.GetOrSetIngredients = GetIngredientsByRecipeId(recipeId);
            rec.GetOrSetIngredientIns = GetIngredientInsByRecipeId(recipeId);
            return rec;
        }

        public Account Login(string accountEmail, string accountPassword) {
            string sql = String.Format("SELECT * FROM accounts WHERE email = '{0}' AND password = '{1}'", accountEmail, accountPassword);
            DataRowCollection res = Query(sql);
            if (res.Count == 1) {
                return new Account(res[0]);
            } else {
                return null;
            }
        }
        #endregion
    }
}

