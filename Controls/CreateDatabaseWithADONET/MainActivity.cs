using System;
using System.Data;
using System.IO;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Mono.Data.Sqlite;
using Android.Runtime;
using Android.Views;
using System.Threading.Tasks;


namespace CreateDatabaseWithADONET
{
    [Activity(Label = "CreateDatabaseWithADONET", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
      
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var btnCreate = FindViewById<Button>(Resource.Id.btnCreateDB);
            var txtResult = FindViewById<TextView>(Resource.Id.txtResults);

            var context = btnCreate.Context;

            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_adonet_db");

            btnCreate.Click +=  async delegate
            {
                try
                {
                    SqliteConnection.CreateFile(pathToDatabase);
                    txtResult.Text = string.Format("Database created sucessfully - filename = {0}\n", pathToDatabase);
                }
                catch (Exception ex)
                {
                    var reason = string.Format("Unable to create the database - reason = {0}", ex.Message);
                    Toast.MakeText(context, reason, ToastLength.Long).Show();
                }
               txtResult.Text += await createTable(pathToDatabase);
            };
        }

        private async Task<string> createTable(string pathToDatabase)
        {
            var connectionString = String.Format("Data Source={0};Version=3;", pathToDatabase);
            try
            {
                using (var conn = new SqliteConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "CREATE TABLE People (PersonID INTEGER PRIMARY KEY AUTOINCREMENT, FirstName ntext, LastName ntext)";
                        command.CommandType = CommandType.Text;
                        await command.ExecuteNonQueryAsync();
                        return "Databse table created sucessfully";
                    }
                }
            }
            catch (Exception ex)
            {
                var reason = string.Format("Failed tom insert into database - reason = {0}", ex.Message);
                return reason;
            }
        }
    }
}

