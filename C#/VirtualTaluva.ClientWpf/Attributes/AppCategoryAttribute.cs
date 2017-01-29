using System;
using IconeIA.App.VieUtil.Enums;

namespace VirtualTaluva.ClientWpf.Attributes
{
    public class AppCategoryAttribute : Attribute
    {
        public AppCategoryEnum Category { get; private set; }
        public AppCategoryAttribute(AppCategoryEnum cat)
        {
            Category = cat;
        }
    }
}
