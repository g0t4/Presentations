// Auto-generated, do not modify
// https://jira.mongodb.org/secure/attachment/11748/MongoAsync.cs

namespace Async
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public static class MongoAsyncExt
    {
        public static Task<Int64> CountAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<Int64>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Count();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Int64> CountAsync(this MongoCollection collection, IMongoQuery query)
        {
            var tcs = new TaskCompletionSource<Int64>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Count(query);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> CreateIndexAsync(this MongoCollection collection, IMongoIndexKeys keys, IMongoIndexOptions options)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.CreateIndex(keys, options);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> CreateIndexAsync(this MongoCollection collection, IMongoIndexKeys keys)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.CreateIndex(keys);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> CreateIndexAsync(this MongoCollection collection, String[] keyNames)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.CreateIndex(keyNames);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<IEnumerable<BsonValue>> DistinctAsync(this MongoCollection collection, String key)
        {
            var tcs = new TaskCompletionSource<IEnumerable<BsonValue>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Distinct(key);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<IEnumerable<BsonValue>> DistinctAsync(this MongoCollection collection, String key, IMongoQuery query)
        {
            var tcs = new TaskCompletionSource<IEnumerable<BsonValue>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Distinct(key, query);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task DropAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<bool>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        collection.Drop();
                        tcs.SetResult(true);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<CommandResult> DropAllIndexesAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<CommandResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.DropAllIndexes();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<CommandResult> DropIndexAsync(this MongoCollection collection, IMongoIndexKeys keys)
        {
            var tcs = new TaskCompletionSource<CommandResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.DropIndex(keys);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<CommandResult> DropIndexAsync(this MongoCollection collection, String[] keyNames)
        {
            var tcs = new TaskCompletionSource<CommandResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.DropIndex(keyNames);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<CommandResult> DropIndexByNameAsync(this MongoCollection collection, String indexName)
        {
            var tcs = new TaskCompletionSource<CommandResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.DropIndexByName(indexName);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task EnsureIndexAsync(this MongoCollection collection, IMongoIndexKeys keys, IMongoIndexOptions options)
        {
            var tcs = new TaskCompletionSource<bool>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        collection.EnsureIndex(keys, options);
                        tcs.SetResult(true);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task EnsureIndexAsync(this MongoCollection collection, IMongoIndexKeys keys)
        {
            var tcs = new TaskCompletionSource<bool>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        collection.EnsureIndex(keys);
                        tcs.SetResult(true);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task EnsureIndexAsync(this MongoCollection collection, String[] keyNames)
        {
            var tcs = new TaskCompletionSource<bool>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        collection.EnsureIndex(keyNames);
                        tcs.SetResult(true);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Boolean> ExistsAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<Boolean>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Exists();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MongoCursor<T>> FindAllAsAsync<T>(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<MongoCursor<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAllAs<T>();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<FindAndModifyResult> FindAndModifyAsync(this MongoCollection collection, IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update)
        {
            var tcs = new TaskCompletionSource<FindAndModifyResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAndModify(query, sortBy, update);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<FindAndModifyResult> FindAndModifyAsync(this MongoCollection collection, IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, Boolean returnNew)
        {
            var tcs = new TaskCompletionSource<FindAndModifyResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAndModify(query, sortBy, update, returnNew);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<FindAndModifyResult> FindAndModifyAsync(this MongoCollection collection, IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, Boolean returnNew, Boolean upsert)
        {
            var tcs = new TaskCompletionSource<FindAndModifyResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAndModify(query, sortBy, update, returnNew, upsert);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<FindAndModifyResult> FindAndModifyAsync(this MongoCollection collection, IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, IMongoFields fields, Boolean returnNew, Boolean upsert)
        {
            var tcs = new TaskCompletionSource<FindAndModifyResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAndModify(query, sortBy, update, fields, returnNew, upsert);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<FindAndModifyResult> FindAndRemoveAsync(this MongoCollection collection, IMongoQuery query, IMongoSortBy sortBy)
        {
            var tcs = new TaskCompletionSource<FindAndModifyResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAndRemove(query, sortBy);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MongoCursor<T>> FindAsAsync<T>(this MongoCollection collection, IMongoQuery query)
        {
            var tcs = new TaskCompletionSource<MongoCursor<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAs<T>(query);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<T> FindOneAsAsync<T>(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<T>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindOneAs<T>();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<T> FindOneAsAsync<T>(this MongoCollection collection, IMongoQuery query)
        {
            var tcs = new TaskCompletionSource<T>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindOneAs<T>(query);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<T> FindOneByIdAsAsync<T>(this MongoCollection collection, BsonValue id)
        {
            var tcs = new TaskCompletionSource<T>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindOneByIdAs<T>(id);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<GeoNearResult<T>> GeoNearAsAsync<T>(this MongoCollection collection, IMongoQuery query, Double x, Double y, Int32 limit)
        {
            var tcs = new TaskCompletionSource<GeoNearResult<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.GeoNearAs<T>(query, x, y, limit);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<GeoNearResult<T>> GeoNearAsAsync<T>(this MongoCollection collection, IMongoQuery query, Double x, Double y, Int32 limit, IMongoGeoNearOptions options)
        {
            var tcs = new TaskCompletionSource<GeoNearResult<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.GeoNearAs<T>(query, x, y, limit, options);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }
        public static Task<CollectionStatsResult> GetStatsAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<CollectionStatsResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.GetStats();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Int64> GetTotalDataSizeAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<Int64>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.GetTotalDataSize();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Int64> GetTotalStorageSizeAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<Int64>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.GetTotalStorageSize();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<IEnumerable<BsonDocument>> GroupAsync(this MongoCollection collection, IMongoQuery query, BsonJavaScript keyFunction, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize)
        {
            var tcs = new TaskCompletionSource<IEnumerable<BsonDocument>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Group(query, keyFunction, initial, reduce, finalize);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<IEnumerable<BsonDocument>> GroupAsync(this MongoCollection collection, IMongoQuery query, IMongoGroupBy keys, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize)
        {
            var tcs = new TaskCompletionSource<IEnumerable<BsonDocument>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Group(query, keys, initial, reduce, finalize);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<IEnumerable<BsonDocument>> GroupAsync(this MongoCollection collection, IMongoQuery query, String key, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize)
        {
            var tcs = new TaskCompletionSource<IEnumerable<BsonDocument>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Group(query, key, initial, reduce, finalize);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Boolean> IndexExistsAsync(this MongoCollection collection, IMongoIndexKeys keys)
        {
            var tcs = new TaskCompletionSource<Boolean>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.IndexExists(keys);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Boolean> IndexExistsAsync(this MongoCollection collection, String[] keyNames)
        {
            var tcs = new TaskCompletionSource<Boolean>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.IndexExists(keyNames);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Boolean> IndexExistsByNameAsync(this MongoCollection collection, String indexName)
        {
            var tcs = new TaskCompletionSource<Boolean>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.IndexExistsByName(indexName);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> InsertAsync<T>(this MongoCollection collection, T document)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Insert(document);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> InsertAsync<T>(this MongoCollection collection, T document, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Insert(document, safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<IEnumerable<SafeModeResult>> InsertBatchAsync<T>(this MongoCollection collection, IEnumerable<T> documents)
        {
            var tcs = new TaskCompletionSource<IEnumerable<SafeModeResult>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.InsertBatch(documents);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<IEnumerable<SafeModeResult>> InsertBatchAsync<T>(this MongoCollection collection, IEnumerable<T> documents, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<IEnumerable<SafeModeResult>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.InsertBatch(documents, safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<Boolean> IsCappedAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<Boolean>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.IsCapped();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MapReduceResult> MapReduceAsync(this MongoCollection collection, BsonJavaScript map, BsonJavaScript reduce, IMongoMapReduceOptions options)
        {
            var tcs = new TaskCompletionSource<MapReduceResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.MapReduce(map, reduce, options);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MapReduceResult> MapReduceAsync(this MongoCollection collection, IMongoQuery query, BsonJavaScript map, BsonJavaScript reduce, IMongoMapReduceOptions options)
        {
            var tcs = new TaskCompletionSource<MapReduceResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.MapReduce(query, map, reduce, options);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MapReduceResult> MapReduceAsync(this MongoCollection collection, IMongoQuery query, BsonJavaScript map, BsonJavaScript reduce)
        {
            var tcs = new TaskCompletionSource<MapReduceResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.MapReduce(query, map, reduce);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MapReduceResult> MapReduceAsync(this MongoCollection collection, BsonJavaScript map, BsonJavaScript reduce)
        {
            var tcs = new TaskCompletionSource<MapReduceResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.MapReduce(map, reduce);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<CommandResult> ReIndexAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<CommandResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.ReIndex();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> RemoveAsync(this MongoCollection collection, IMongoQuery query)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Remove(query);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> RemoveAsync(this MongoCollection collection, IMongoQuery query, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Remove(query, safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> RemoveAsync(this MongoCollection collection, IMongoQuery query, RemoveFlags flags)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Remove(query, flags);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> RemoveAsync(this MongoCollection collection, IMongoQuery query, RemoveFlags flags, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Remove(query, flags, safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> RemoveAllAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.RemoveAll();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> RemoveAllAsync(this MongoCollection collection, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.RemoveAll(safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task ResetIndexCacheAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<bool>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        collection.ResetIndexCache();
                        tcs.SetResult(true);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> SaveAsync<T>(this MongoCollection collection, T document)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Save(document);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> SaveAsync<T>(this MongoCollection collection, T document, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Save(document, safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<String> ToStringAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<String>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.ToString();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> UpdateAsync(this MongoCollection collection, IMongoQuery query, IMongoUpdate update)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Update(query, update);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> UpdateAsync(this MongoCollection collection, IMongoQuery query, IMongoUpdate update, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Update(query, update, safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> UpdateAsync(this MongoCollection collection, IMongoQuery query, IMongoUpdate update, UpdateFlags flags)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Update(query, update, flags);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<SafeModeResult> UpdateAsync(this MongoCollection collection, IMongoQuery query, IMongoUpdate update, UpdateFlags flags, SafeMode safeMode)
        {
            var tcs = new TaskCompletionSource<SafeModeResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Update(query, update, flags, safeMode);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<ValidateCollectionResult> ValidateAsync(this MongoCollection collection)
        {
            var tcs = new TaskCompletionSource<ValidateCollectionResult>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Validate();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MongoCursor<T>> FindAsync<T>(this MongoCollection<T> collection, IMongoQuery query)
        {
            var tcs = new TaskCompletionSource<MongoCursor<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.Find(query);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<MongoCursor<T>> FindAllAsync<T>(this MongoCollection<T> collection)
        {
            var tcs = new TaskCompletionSource<MongoCursor<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindAll();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<T> FindOneAsync<T>(this MongoCollection<T> collection)
        {
            var tcs = new TaskCompletionSource<T>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindOne();
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<T> FindOneAsync<T>(this MongoCollection<T> collection, IMongoQuery query)
        {
            var tcs = new TaskCompletionSource<T>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindOne(query);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<T> FindOneByIdAsync<T>(this MongoCollection<T> collection, BsonValue id)
        {
            var tcs = new TaskCompletionSource<T>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.FindOneById(id);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<GeoNearResult<T>> GeoNearAsync<T>(this MongoCollection<T> collection, IMongoQuery query, Double x, Double y, Int32 limit)
        {
            var tcs = new TaskCompletionSource<GeoNearResult<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.GeoNear(query, x, y, limit);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }

        public static Task<GeoNearResult<T>> GeoNearAsync<T>(this MongoCollection<T> collection, IMongoQuery query, Double x, Double y, Int32 limit, IMongoGeoNearOptions options)
        {
            var tcs = new TaskCompletionSource<GeoNearResult<T>>();
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        var result = collection.GeoNear(query, x, y, limit, options);
                        tcs.SetResult(result);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                });
            return tcs.Task;
        }
    }
}