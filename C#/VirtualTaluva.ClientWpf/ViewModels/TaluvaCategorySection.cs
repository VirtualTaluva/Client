using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Com.Ericmas001.Common;
using Com.Ericmas001.Windows.ViewModels;
using Com.Ericmas001.Windows.ViewModels.Sections;
using IconeIA.App.VieUtil.Enums;
using VirtualTaluva.ClientWpf.Attributes;

namespace VirtualTaluva.ClientWpf.ViewModels
{
    public class TaluvaCategorySection : CategorySection<AppCategoryEnum>
    {
        public TaluvaCategorySection(AppCategoryEnum cat)
            : base(cat) 
        { 
        }

        public override BaseTabViewModel CreateContentTab()
        {
            return null;
        }
        public override int SectionWidth
        {
            get
            {
                return 600;
            }
        }


        private static Dictionary<AppCategoryEnum, Type> m_CategoryToSection;
        public static TaluvaCategorySection CreateSection(AppCategoryEnum cat)
        {
            if (m_CategoryToSection == null)
            {
                m_CategoryToSection = new Dictionary<AppCategoryEnum, Type>();
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(TaluvaCategorySection))))
                    m_CategoryToSection.Add(type.GetAttributeValue<AppCategoryAttribute, AppCategoryEnum>(att => att.Category), type);
            }

            if (m_CategoryToSection.ContainsKey(cat))
            {
                ConstructorInfo ctor = m_CategoryToSection[cat].GetConstructor(new Type[0]);
                return ctor.Invoke(new object[0]) as TaluvaCategorySection;
            }

            return new TaluvaCategorySection(cat);
        }
    }
}
