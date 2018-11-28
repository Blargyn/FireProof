using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FireProof
{
    public class RoomModel
    {
        [PrimaryKey]
        public string roomName
        {
            get;
            set;
        }

        //public int numItems
    }
}
