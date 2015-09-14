using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.MicroErp.Common.Attributes
{
    public sealed class IsBindAttribute : Attribute
    {
        public bool Bind { get; private set; }

        public string Name { get; private set; }

        public IsBindAttribute(string name)
        {
            this.Name = name;
            this.Bind = true;
        }

        public IsBindAttribute(bool bind = true)
        {
            this.Bind = bind;
        }
    }
}
