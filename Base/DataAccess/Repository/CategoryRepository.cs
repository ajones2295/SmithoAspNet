﻿using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.DataModels;

namespace DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private DatabaseContext _db;
        public CategoryRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }

        public string GetName(int? id)
        {
            return _db.Categories.Find(id).Name;
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}