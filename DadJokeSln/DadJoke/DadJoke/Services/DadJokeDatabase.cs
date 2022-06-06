using System;
using System.Collections.Generic;
using System.Text;
using DadJokes.Services.Interfaces;
using DadJokes.Models;
using SQLite;

namespace DadJokes
{
    public class DadJokeDatabase : ILocalDatabase
    {
        private SQLiteConnection _database;
               
        public DadJokeDatabase()
        {
            ///
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + "joke.db";

            _database = new SQLiteConnection(path,  SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            _database.CreateTable<DadJoke>();
        }

        public List<DadJoke> GetJokes()
        {
            return _database.Table<DadJoke>().OrderByDescending(x => x.JokeDate).ToList();
        }

        public void SaveDadJoke(DadJoke joke)
        {
            _database.Insert(joke);
        }
    }
}
