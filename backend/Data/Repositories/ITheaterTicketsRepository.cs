using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace backend.Data.Repositories
{
    public interface ITheaterTicketsRepository
    {
        Task<TableResult> CreateItemAsync<T>(T item) where T : ITableEntity;
        Task<TableResult> UpdateItemAsync<T>(Expression<Func<T, bool>> predicate, T item) where T : ITableEntity;
        Task<TableResult> DeleteItemAsync<T>(Expression<Func<T, bool>> predicate, T item) where T : ITableEntity;
        Task<IEnumerable<T>> GetAllItemsAsync<T>() where T : class;
        Task<TableResult> GetItemAsync<T>(Expression<Func<T, bool>> predicate) where T : ITableEntity;
        Task<IEnumerable<T>> GetItemsAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}