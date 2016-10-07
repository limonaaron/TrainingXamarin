using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateDatabaseWithSQLite
{
    [Activity(Label = "CreateDatabaseWithSQLite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var btnCreate = FindViewById<Button>(Resource.Id.btnCreateDB);
            var btnSingle = FindViewById<Button>(Resource.Id.btnCreateSingle);
            var btnList = FindViewById<Button>(Resource.Id.btnList);
            var txtResult = FindViewById<TextView>(Resource.Id.txtResults);

            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlnet.db");

            btnSingle.Enabled = btnList.Enabled = false;

            btnCreate.Click += async delegate 
            {
                var result = await CreateDatabaseAsync(pathToDatabase);
                txtResult.Text = result + "\n";
                if (result == "Database created")
                    btnList.Enabled = btnSingle.Enabled = true;
            };

            btnSingle.Click += async delegate 
            {
                var result = await InsertUpdateDataAsync(new Person { FirstName=string.Format("Jhon {0}",DateTime.Now.Ticks),
                                                           LastName = "Smith"},pathToDatabase);
                var records = await FindNumberRecordsAsync(pathToDatabase);
                txtResult.Text += String.Format("{0}\nNumber of records = {1}\n", result, records);
            };

            btnList.Click += async delegate 
            {
                var peopleList = new List<Person>
                {
                    new Person { FirstName= "Miguel", LastName=string.Format("de Icaza ({0})",DateTime.Now.Ticks)},
                    new Person { FirstName = string.Format("Kevin {0}",DateTime.Now.Ticks),LastName="Mullins" },
                    new Person { FirstName="Amy",LastName=string.Format("Burns ({0})", DateTime.Now.Ticks)}                    
                };

                var result = await InsertUpdateAllDataAsync(peopleList, pathToDatabase);
                var records = await FindNumberRecordsAsync(pathToDatabase);
                txtResult.Text += string.Format("{0}\nNumber of records = {1}\n",result,records);
            };
        }

        private async Task<string> CreateDatabaseAsync(string path)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);

                await connection.CreateTableAsync<Person>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        private async Task<string> InsertUpdateDataAsync(Person data, string path)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                if (await db.InsertAsync(data) != 0)
                    await db.UpdateAsync(data);
                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        private async Task<string> InsertUpdateAllDataAsync(IEnumerable<Person> data, string path)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                if (await db.InsertAllAsync(data) != 0)
                    await db.UpdateAllAsync(data);
                return "List of data inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        private async Task<int> FindNumberRecordsAsync(string path)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                var count = await db.ExecuteScalarAsync<int>("SELECT Count(*) FROM Person");

                return count;
            }
            catch (SQLiteException ex)
            {
                return -1;
            }
        }
    }
}

