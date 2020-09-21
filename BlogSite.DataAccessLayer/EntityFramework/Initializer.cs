using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.EntityFramework
{
   public class Initializer:CreateDatabaseIfNotExists<DataContext>
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);    
        }
    }
}
