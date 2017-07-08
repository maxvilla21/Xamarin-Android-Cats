using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Cats.CustomAdapters;
using Cats.SAL;
using Newtonsoft.Json;


namespace Cats.Client
{
    [Activity(Label = "Cats", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Complex _data;
        private ListView _listViewCats;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _listViewCats = FindViewById<ListView>(Resource.Id.listViewCats);

            _listViewCats.ItemClick += _listViewCats_ItemClick;

            _data = (Complex) this.FragmentManager.FindFragmentByTag("Data");
            if (_data == null)
            {
                _data = new Complex();
                var fragmentTransaction = this.FragmentManager.BeginTransaction();
                fragmentTransaction.Add(_data, "Data");
                fragmentTransaction.Commit();

                GetCats();
            }
            else
            {
                _listViewCats.Adapter = _data.CatsAdapter;
            }
        }

        private void _listViewCats_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var adapter = (CatAdapter)_listViewCats.Adapter;
            var cat = adapter[e.Position];

            Intent intent = new Intent(this, typeof(CatDetailActivity));

            intent.PutExtra("Cat", JsonConvert.SerializeObject(cat));
            StartActivity(intent);
        }

        public async void GetCats()
        {
            var service = new ServiceClient();
            var cats = await service.GetCatsAsync();
            _data.CatsAdapter = new CatAdapter(this, cats, Resource.Layout.ListItem, Resource.Id.tvName,
                Resource.Id.tvPrice, Resource.Id.imageView1);
            _listViewCats.Adapter = _data.CatsAdapter;
        }
    }
}

