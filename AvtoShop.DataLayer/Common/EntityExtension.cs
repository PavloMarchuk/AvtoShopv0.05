using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoShop.DataLayer.Common
{
    public abstract class EntityExtension<TKey> : Entity<TKey>
    {
        public abstract string Name { get; set; }
    }
}
