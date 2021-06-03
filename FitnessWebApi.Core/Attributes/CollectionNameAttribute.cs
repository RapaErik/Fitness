using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Attributes
{
    public class CollectionNameAttribute : Attribute
    {
        public string CollectionName { get; }
        public CollectionNameAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

    }
}
