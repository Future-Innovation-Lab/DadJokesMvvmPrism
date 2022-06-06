using DadJokes.Models.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DadJokes.Services.Interfaces
{
    public interface IRemoteServer
    {
        Task<DadJoke> GetRemoteJoke();
    }
}
