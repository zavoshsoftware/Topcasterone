using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;
using ViewModels;

//using ViewModels;

namespace Helpers
{
    public  class BaseViewModelHelper
    {
        private  DatabaseContext db = new DatabaseContext();

        public  List<ProductGroup> GetMenuProductGroup()
        {
            return db.ProductGroups.Where(c => c.IsDeleted == false&&c.IsActive).ToList();
        }
        //public  List<Blog> GetFooterBlog()
        //{
        //    return db.Blogs.Where(c => c.IsDeleted == false&&c.IsActive)
        //        .OrderByDescending(current => current.CreationDate).Take(3).ToList();
        //}
    }
}