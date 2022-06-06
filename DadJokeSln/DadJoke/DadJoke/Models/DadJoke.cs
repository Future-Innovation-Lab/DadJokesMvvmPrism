using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DadJokes.Models
{
    public class DadJoke
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Joke { get; set; }

        public DateTime JokeDate { get; set; }

    }
}
