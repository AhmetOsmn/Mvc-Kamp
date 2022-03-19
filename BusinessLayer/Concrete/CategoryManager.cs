﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Create(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetCategoryByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDal.ReadAll();
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
