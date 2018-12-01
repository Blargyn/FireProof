using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace FireProof
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class viewAndManagePage : ContentPage
	{
		public viewAndManagePage ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<string>(this, "PopUpRoom", (room) => Handle_AddRoom(room));
        }

        async void Handle_AddRoom(string sender)//, EventArgs e)
        {
            var room = new RoomModel
            {
                roomName = sender,
            };
            await App.Database.SaveRoomAsync(room); //should check for duplicates before saving

            //try to update immediately upon adding a room
            var allRooms = await App.Database.GetAllRooms();

            var roomList = new ObservableCollection<RoomModel>();
            allRooms.ForEach(x => roomList.Add(x));

            RoomListView.ItemsSource = roomList;
        }

        private void Handle_AddRPopup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new roomPopup());
        }

        async void Handle_GetRooms(object sender, EventArgs e)
        {
            var allRooms = await App.Database.GetAllRooms();

            var roomList = new ObservableCollection<RoomModel>();
            allRooms.ForEach(x => roomList.Add(x));

            RoomListView.ItemsSource = roomList;
        }

        async void Handle_ItemPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new itemsPage());
        }


    }
}