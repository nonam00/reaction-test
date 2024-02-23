using Backend.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApi.Models;

public class ResultService
{
    private readonly IMongoCollection<Result> _resultsCollection;

    public ResultService(
        IOptions<ResultsDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

        _resultsCollection = mongoDatabase.GetCollection<Result>(settings.Value.CollectionName);
    }

    public async Task<List<Result>> GetAsync() =>
        await _resultsCollection.Find(_ => true).ToListAsync();

    public async Task<Result?> GetAsync(string id) =>
        await _resultsCollection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Result newBook) =>
        await _resultsCollection.InsertOneAsync(newBook);

    //public async Task UpdateAsync(string id, Result updatedBook) =>
    //	await _resultsCollection.ReplaceOneAsync(x => x.Id.ToString() == id, updatedBook);

    //public async Task RemoveAsync(string id) =>
    //	await _resultsCollection.DeleteOneAsync(x => x.Id.ToString() == id);
}