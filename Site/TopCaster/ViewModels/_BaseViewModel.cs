using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers;
using Models;

namespace  ViewModels
{
    public class _BaseViewModel
    {
        readonly BaseViewModelHelper _baseViewModelHelper = new BaseViewModelHelper();
        public List<ProductGroup> MenuProductGroups
        {
            get { return _baseViewModelHelper.GetMenuProductGroup(); }
        }
    }

    
}