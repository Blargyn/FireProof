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
            await App.Database.SaveRoomAsync(room);

            //try to update immediately upon adding a room
            var allRooms = await App.Database.GetAllRooms();

            var roomList = new ObservableCollection<RoomModel>();
            allRooms.ForEach(x => roomList.Add(x));

            RoomListView.ItemsSource = roomList;
        }

        private void Handle_AddPopup(object sender, EventArgs e)
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


    }
}