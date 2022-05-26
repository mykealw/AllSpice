using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class StepsService
    {
        private readonly StepsRepository _repo;
        public StepsService(StepsRepository repo)
        {
            _repo = repo;
        }
    }
}