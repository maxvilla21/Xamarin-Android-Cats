using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using Cats.Entities;
using Newtonsoft.Json;

namespace Cats.Client
{
    [Activity(Label = "CatDetailActivity")]
    public class CatDetailActivity : Activity
    {
        private Cat cat;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CatDetail);

            var tvName = FindViewById<TextView>(Resource.Id.tvName);
            var tvDescription = FindViewById<TextView>(Resource.Id.tvDescription); 
            var imageCat = FindViewById<ImageView>(Resource.Id.imageCat);

            var btnWebsite = FindViewById<Button>(Resource.Id.btnWebsite);
            btnWebsite.Click += BtnWebsite_Click;

            cat= JsonConvert.DeserializeObject<Cat>(Intent.GetStringExtra("Cat"));

            tvName.Text = cat.Name;
            tvDescription.Text = cat.Description;
            Koush.UrlImageViewHelper.SetUrlDrawable(imageCat, cat.Image);
            ActionBar.Title = cat.Name;
        }

        private void BtnWebsite_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse(cat.WebSite);
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }
    }
}