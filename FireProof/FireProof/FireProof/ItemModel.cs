using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FireProof
{
    public class ItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID //ID automatically given to uniquely identify items
        {
            get;
            set;
        }
        public string roomName //the room that the object is in
        {
            get;
            set;
        }
        public string itemName //the item name
        {
            get;
            set;
        }
        public string value //the value of the item
        {
            get;
            set;
        }
        public string quantity
        {
            get;
            set;
        }
    }
}
