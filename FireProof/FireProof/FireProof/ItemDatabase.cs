using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;

namespace FireProof
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ItemModel>().Wait();
            database.CreateTableAsync<RoomModel>().Wait();
        }

        public Task<int> SaveItemAsync(ItemModel item)
        {
            if(item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveRoomAsync(RoomModel room)
        {
            if (room.roomName != "NULL")
            {
                return database.UpdateAsync(room);
            }
            else
            {
                return database.InsertAsync(room);
            }
        }

        public Task<List<ItemModel>> GetAllItems()
        {
            return database.QueryAsync<ItemModel>("SELECT * FROM [ItemModel]");
        }

        public Task<List<RoomModel>> GetAllRooms()
        {
            return database.QueryAsync<RoomModel>("SELECT * from [RoomModel]");
        }
    }
}
