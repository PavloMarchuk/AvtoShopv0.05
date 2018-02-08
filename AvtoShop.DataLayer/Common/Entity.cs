using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoShop.DataLayer.Common
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
