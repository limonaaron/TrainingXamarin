using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Database;

namespace UpdateUsersProfile
{
    [Activity(Label = "UpdateUsersProfile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate 
            {
                NameOwner();
                if (ReadBackName())
                    ViewProfile();
            };
        }

        void NameOwner()
        {
            ContentValues values = new ContentValues();
            values.Put(ContactsContract.Contacts.InterfaceConsts.DisplayName, "Aaron Francisco");
            ContentResolver.Update(ContactsContract.Profile.ContentRawContactsUri, values, null, null);
        }

        bool ReadBackName()
        {
            Android.Net.Uri uri = ContactsContract.Profile.ContentUri;
            string[] projection = { ContactsContract.Contacts.InterfaceConsts.DisplayName };

            CursorLoader loader = new CursorLoader(this, uri, projection, null, null, null);
            ICursor cursor = (ICursor)loader.LoadInBackground();

            if (cursor != null)
            {
                if (cursor.MoveToFirst())
                {
                    Console.WriteLine(cursor.GetString(cursor.GetColumnIndex(projection[0])));
                    return true;
                }
            }
            return false;
        }

        void ViewProfile()
        {
            Intent intent = new Intent(
                Intent.ActionView, ContactsContract.Profile.ContentUri);
            StartActivity(intent);
        }
    }
}

