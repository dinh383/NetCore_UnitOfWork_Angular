﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Components
{
    public class TeachersViewComponent : ViewComponent
    {
        public TeachersViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
