﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MoviesAPI.Data
{
    public class MoviesService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MoviesService(IOptions<MoviesDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _movies = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Movie>(options.Value.MoviesCollectionName);
        }

        public async Task<IEnumerable<Movie>> GetAllMovies() =>
            await _movies.Find(_ => true).ToListAsync();

        public async Task<Movie> GetById(string id) =>
            await _movies.Find(m => m._id == id).FirstOrDefaultAsync();

        public async Task Create(Movie newMovie) =>
            await _movies.InsertOneAsync(newMovie);

        public async Task Update(string id, Movie updateMovie) =>
            await _movies.ReplaceOneAsync(m => m._id == id, updateMovie);

        public async Task Remove(string id) =>
            await _movies.DeleteOneAsync(m => m._id == id);
    }
}