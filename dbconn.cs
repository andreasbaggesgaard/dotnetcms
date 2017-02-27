using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmsProject
{
    public class dbconn
    {
        public static string Configuration()
        {
           return @"data source = .\sqlexpress; integrated security = true; database = CMS";
        }
    }
}