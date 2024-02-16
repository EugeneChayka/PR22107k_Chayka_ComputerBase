﻿using Practich3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practich3.Views.Pages
{
    internal class Helper
    {
        private static CompBaseEntities s_firstDBEntities;
        public static CompBaseEntities GetContext()
        {
            if (s_firstDBEntities == null)
            {
                s_firstDBEntities = new CompBaseEntities();
            }
            return s_firstDBEntities;
        }
    }
}
