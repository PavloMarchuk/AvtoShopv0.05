using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoShop.DataLayer.Common
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
