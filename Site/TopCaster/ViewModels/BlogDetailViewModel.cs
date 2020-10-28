﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels
{
    public class BlogDetailViewModel : _BaseViewModel
    {
        public Blog Blog { get; set; }
        public List<Blog> RecentBlogs { get; set; }
        public List<Blog> PopularBlogs { get; set; }
        public List<BlogComment> Comments { get; set; }
    }
}