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

            //MessagingCenter.Subscribe<ItemModel>(this, "PopUpItem", (item) => Handle_AddItem(item, roomTitle));
            //This should never be called
        }

        public itemsPage(RoomModel room)
        {
            InitializeComponent();

            bool initialized = false;

            if (initialized == false)
            {
                string roomName = room.roomName;
                Handle_GetItems(roomName);

                MessagingCenter.Subscribe<ItemModel>(this, "PopUpItem", (item) => Handle_AddItem(item, roomName));
            }

            initialized = true;
        }

        async void Handle_AddItem(ItemModel item, string roomTitle)
        {
            item.roomName = roomTitle;
            await App.Database.SaveItemAsync(item);

            var allItems = await App.Database.GetRoomItems(roomTitle);

            var itemList = new ObservableCollection<ItemModel>();
            allItems.ForEach(x => itemList.Add(x));

            ItemListView.ItemsSource = itemList;
        }

        private void Handle_AddIPopup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new itemPopup());
        }

        async void Handle_GetItems(string roomTitle)
        {
            var allItems = await App.Database.GetRoomItems(roomTitle);

            var itemList = new ObservableCollection<ItemModel>();
            allItems.ForEach(x => itemList.Add(x));

            ItemListView.ItemsSource = itemList;
        }

        async void Handle_DeleteItem(object sender, EventArgs e)
        {
            var itemInfo = (Button)sender;
            var item = (ItemModel)itemInfo.CommandParameter;
            string roomTitle = item.roomName;

            await App.Database.DeleteItem(item);

            Handle_GetItems(roomTitle);
        }
	}
}