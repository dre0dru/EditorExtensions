using System;
using UnityEngine;

namespace Dre0Dru.EditorExtensions.Attributes
{
    public class ConstantStringAttribute : PropertyAttribute
    {
        private readonly Type _source;
        private readonly bool _flatten;

        public Type Source => _source;
        public bool Flatten => _flatten;
        
        public ConstantStringAttribute(Type source, bool flatten = false)
        {
            _source = source;
            _flatten = flatten;
        }
    }
}
