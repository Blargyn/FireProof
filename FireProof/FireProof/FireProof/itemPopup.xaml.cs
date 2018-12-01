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
    public partial class itemPopup
    {
        public itemPopup()
        {
            InitializeComponent();
        }

        private void Handle_AddItemPopup(object sender, EventArgs e)
        {
            var item = new ItemModel
            {
                roomName = "Stuff",
                itemName = nameEntry.Text,
                value = valueEntry.Text,
                quantity = quantityEntry.Text,
            };

            MessagingCenter.Send<ItemModel>(item, "PopUpItem");
        }
    }
}