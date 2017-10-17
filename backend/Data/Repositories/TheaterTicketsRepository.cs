using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using backend.Data.Configuration;
using backend.Domain;
using Microsoft.Azure;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace backend.Data.Repositories
{
    public class TheaterTicketsRepository: ITheaterTicketsRepository
    {
        private DatabaseSettings _databaseSettings;
        private CloudTableClient _cloudTableClient;
        private CloudTable _cloudTable;

        public TheaterTicketsRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
            var storageAccount = CloudStorageAccount.Parse(_databaseSettings.StorageConnectionString);

            _cloudTableClient = storageAccount.CreateCloudTableClient();
            _cloudTable = _cloudTableClient.GetTableReference(_databaseSettings.TableName);

            _cloudTable.CreateIfNotExistsAsync().Wait();
        }

        public async Task<TableResult> CreateItemAsync<T>(T item) where T : ITableEntity
        {
            return await _cloudTable.ExecuteAsync(TableOperation.Insert(item));
        }

        public async Task<TableResult> UpdateItemAsync<T>(Expression<Func<T, bool>> predicate, T item) where T : ITableEntity
        {
            return await _cloudTable.ExecuteAsync(TableOperation.Replace(item));
        }

        public async Task<TableResult> DeleteItemAsync<T>(Expression<Func<T, bool>> predicate, T item) where T : ITableEntity
        {
            return await _cloudTable.ExecuteAsync(TableOperation.Delete(item));
        }

        public Task<IEnumerable<T>> GetAllItemsAsync<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TableResult> GetItemAsync<T>(Expression<Func<T, bool>> predicate) where T : ITableEntity
        {
            //_cloudTable.ExecuteQuerySegmentedAsync(new TableQuery() {}, );

            var result = _cloudTable.ExecuteAsync(TableOperation.Retrieve<T>("",""));

            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetItemsAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }
    }
}