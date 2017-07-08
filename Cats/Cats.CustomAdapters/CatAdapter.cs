using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Android.App;
using Android.Views;
using Android.Widget;
using Cats.Entities;

namespace Cats.CustomAdapters
{
    public class CatAdapter : BaseAdapter<Cat>
    {
        List<Cat> Items; // Datos de cada evidencia de laboratorio.
        Activity Context; // Activity donde se utilizará este Adapter.
        int ItemLayoutTemplate;

        int CatImageViewID; 
        int CatNameViewID;
        int CantPriceViewID;


        public CatAdapter(Activity context, List<Cat> Cats, int itemLayoutTemplate, int catNameViewID, int cantPriceViewID,int catImageViewID)
        {
            this.Context = context;
            this.Items = Cats;
            this.ItemLayoutTemplate = itemLayoutTemplate;

            this.CatImageViewID=catImageViewID;
            this.CatNameViewID=catNameViewID;
            this.CantPriceViewID=cantPriceViewID;
        }

        public override long GetItemId(int position)
        {
            return Items[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Obtenemos el elemento del cual se requiere la Vista
            var Item = Items[position];
            View ItemView; // Vista que vamos a devolver
            if (convertView == null)
            {
                ItemView = Context.LayoutInflater.Inflate(ItemLayoutTemplate, null /* No hay View padre*/);
            }
            else
            {
                ItemView = convertView;
            }

            // Establecemos los datos del elemento dentro del View
            ItemView.FindViewById<TextView>(CatNameViewID).Text = Item.Name;
            ItemView.FindViewById<TextView>(CantPriceViewID).Text = String.Format("{0:C}",Item.Price);
            Koush.UrlImageViewHelper.SetUrlDrawable(ItemView.FindViewById<ImageView>(CatImageViewID), Item.Image);
            return ItemView;
        }

        public override int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public override Cat this[int position]
        {
            get
            {
                return Items[position];
            }
        }
    }
}
