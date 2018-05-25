using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood2.Models
{
    public class Group<K, T>
    {
        public K Key;
        public IEnumerable<T> Values;
    }
}