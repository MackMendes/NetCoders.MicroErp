using System;

namespace NetCoders.MicroErp.Common.Attributes
{
    /// <summary>
    /// Classe que faz um Attribute Customizado (criar uma Data Annotation)
    /// </summary>
    public sealed class IsIdAttribute : Attribute
    {
        public bool IsId { get; private set; }

        public IsIdAttribute()
        {
            IsId = true;
        }
    }
}
