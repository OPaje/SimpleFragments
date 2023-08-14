using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.OS;
using Android.Widget;

namespace SimpleFragments.Droid
{
    [Activity(Label = "SimpleFragments", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            SetContentView(Resource.Layout.activity_main);
            RadioButton radio_object = FindViewById<RadioButton>(Resource.Id.rb_object);
            RadioButton radio_track = FindViewById<RadioButton>(Resource.Id.rb_track);
            Button btnFragment2 = FindViewById<Button>(Resource.Id.btnFragment2);

            radio_object.Click += RadioButtonClick;
            radio_track.Click += RadioButtonClick;
            btnFragment2.Click += ButtonClick;
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            var objectFragment = new ObjectFragment();
            var trackFragment = new TrackFragment();
            var deleteFragment = new DeleteFragment();

            if(rb.Text == "Object")
            {
                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.flFragment, objectFragment)
                    .Add(Resource.Id.flFragment, deleteFragment)
                    .Commit();

            }
            else
            {
                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.flFragment2, trackFragment)
                    .Commit();
            }


            //Toast.MakeText(this, id, ToastLength.Short).Show();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            var secondFragment = new SecondFragment();

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.flFragment, secondFragment)
                .Commit();
        }
    }
}