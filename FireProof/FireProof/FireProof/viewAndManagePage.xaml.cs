using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireProof
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class viewAndManagePage : ContentPage
	{
		public viewAndManagePage ()
		{
			InitializeComponent ();
		}

        async void Handle_AddRoom(object sender, EventArgs e)
        {
            var room = new RoomModel
            {
                roomName = roomEntry.Text,
            };
            await App.Database.SaveRoomAsync(room);
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