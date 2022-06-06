using DadJokes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadJokes.Services.Interfaces
{
    public interface ILocalDatabase
    {
        List<DadJoke> GetJokes();
        void SaveDadJoke(DadJoke joke);
    }
}
