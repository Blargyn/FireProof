using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireProof
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class itemsPage : ContentPage
	{
		public itemsPage ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<ItemModel>(this, "PopUpItem", (item) => Handle_AddItem(item));
        }


        async void Handle_AddItem(ItemModel item)//, EventArgs e)
        {
            await App.Database.SaveItemAsync(item); //should check for duplicates before saving

            //try to update immediately upon adding a room
            var allItems = await App.Database.GetAllItems();

            var itemList = new ObservableCollection<ItemModel>();
            allItems.ForEach(x => itemList.Add(x));

            ItemListView.ItemsSource = itemList;
        }

        private void Handle_AddIPopup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new itemPopup());
        }

        async void Handle_GetItems(object sender, EventArgs e)
        {
            var allItems = await App.Database.GetAllItems();

            var itemList = new ObservableCollection<ItemModel>();
            allItems.ForEach(x => itemList.Add(x));

            ItemListView.ItemsSource = itemList;
        }
    }
}
