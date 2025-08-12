using MyMongoApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MyMongoApi.Services;

public class BookService
{
    private readonly IMongoCollection<Book> _bookCollection;

    public BookService(IOptions<MongoDBSettings> mongoSettings)
    {
        var mongoClient = new MongoClient(mongoSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
        _bookCollection = mongoDatabase.GetCollection<Book>(mongoSettings.Value.CollectionName);
    }

    public async Task<List<Book>> GetAsync() =>
        await _bookCollection.Find(_ => true).ToListAsync();

    public async Task<Book?> GetAsync(string id) =>
        await _bookCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Book newBook) =>
        await _bookCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Book updatedBook) =>
        await _bookCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _bookCollection.DeleteOneAsync(x => x.Id == id);
}
