﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Team5BookStore
{
    public static class MasterPagePicker
    {
        public static void Picker(Page page)
        {
            if (page.Session[Constants.USER_ID] != null)
                page.MasterPageFile = "~/AllUsers.Master";
            else
                page.MasterPageFile = "~/AnonUsers.Master";
        }
      
    }
}