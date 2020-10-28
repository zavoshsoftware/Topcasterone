using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class HomeViewModel : _BaseViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<TextTypeItem> UnderSliderText { get; set; }
        public List<Team> TeamMembers { get; set; }
        public TextTypeItem About { get; set; }
        public TextTypeItem History { get; set; }
        public TextTypeItem Proccess { get; set; }

        public List<TextTypeItem> TechText { get; set; }

        public List<Product> Products { get; set; }

        public List<Blog> LatestBlogs { get; set; }
    }
}