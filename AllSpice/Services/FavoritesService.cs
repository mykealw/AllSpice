using System;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;
        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite Create(Favorite favoriteData)
        {
            return _repo.Create(favoriteData);
        }

        internal void Delete(int id, string userId)
        {
            Favorite favorite = GetById(id);
            if (favorite.AccountId != userId)
            {
                throw new Exception("This isn't your favorite to delete.");
            }
            _repo.Delete(id);
        }

        internal Favorite GetById(int id)
        {
            Favorite favorite = _repo.GetById(id);
            if (favorite == null)
            {
                throw new Exception("invalid favorite?!?");
            }
            return favorite;
        }
    }
}