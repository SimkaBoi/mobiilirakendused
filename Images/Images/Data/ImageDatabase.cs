using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Images.Data
{
    public class ImageDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ImageDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ImageData>().Wait();
            _database.CreateTableAsync<UserData>().Wait();
        }
        // notes
        public Task<List<ImageData>> GetImagesAsync()
        {
            return _database.Table<ImageData>().ToListAsync();
        }

        public Task<ImageData> GetImageAsync(int id)
        {
            return _database.Table<ImageData>()
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveImageAsync(ImageData image)
        {
            if (image.Id != 0)
            {
                return _database.UpdateAsync(image);
            }
            else
            {
                return _database.InsertAsync(image);
            }
        }

        public Task<int> DeleteImageAsync(ImageData image)
        {
            return _database.DeleteAsync(image);
        }

        public Task<int> GetImageCount()
        {
            return _database.Table<ImageData>().CountAsync();
        }

        //users

        public Task<List<UserData>> GetUsersAsync()
        {
            return _database.Table<UserData>().ToListAsync();
        }

        public Task<UserData> GetUserAsync(int id)
        {
            return _database.Table<UserData>()
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(UserData user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(UserData user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<int> GetUserCount()
        {
            return _database.Table<UserData>().CountAsync();
        }
    }
}
