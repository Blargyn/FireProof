using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var roomsEntry = roomEntry.Text;
            MessagingCenter.Send<string>(roomsEntry, "PopUpRoom");
        }
    }
}