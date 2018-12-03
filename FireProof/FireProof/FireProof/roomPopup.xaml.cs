using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireProof
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class roomPopup
	{
        public roomPopup()
        {
            InitializeComponent();
        }

        private void Handle_AddRoomPopup(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Room Added");


            var roomsEntry = roomEntry.Text;
            MessagingCenter.Send<string>(roomsEntry, "PopUpRoom");
        }
    }
}