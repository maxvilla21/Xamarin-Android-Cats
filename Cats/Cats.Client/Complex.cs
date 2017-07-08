using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cats.CustomAdapters;

namespace Cats.Client
{
    public class Complex : Fragment
    {
        public override void OnCreate(Bundle saveInstanteState)
        {
            base.OnCreate(saveInstanteState);
            RetainInstance = true;

        }

        public CatAdapter CatsAdapter { get; set; }
     

    }
}