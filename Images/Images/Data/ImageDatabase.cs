using Images.Models;
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
            _database.CreateTableAsync<ImageWithInfo>().Wait();
        }
        // notes
        public Task<List<ImageWithInfo>> GetImagesAsync()
        {
            return _database.Table<ImageWithInfo>().ToListAsync();
        }

        public Task<ImageWithInfo> GetImageAsync(int id)
        {
            return _database.Table<ImageWithInfo>()
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveImageAsync(ImageWithInfo image)
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

        public Task<int> DeleteImageAsync(ImageWithInfo image)
        {
            return _database.DeleteAsync(image);
        }
    }
}
