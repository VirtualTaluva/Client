using System.Security.Claims;
using System.Windows.Media;
using Com.Ericmas001.Windows.ViewModels;
using Com.Ericmas001.Windows.ViewModels.Sections;
using IconeIA.App.VieUtil.Enums;

namespace VirtualTaluva.ClientWpf.ViewModels
{
    public class NewTaskViewModel : MultiCategoriesNewTabViewModel<AppCategoryEnum>
    {
        protected override string IconImageName => "Flash";

        public class ActionButtonSectionOld : ActionButtonSection
        {
            public ActionButtonSectionOld()
            {
                Info = new TabSectionInfo
                {
                    Description = "SandBox",
                    ButtonBrush = Colors.Red,
                    Background = Brushes.Red,
                    IconImageBigName = "Taluva",
                    IconImageSmallName = "Taluva",
                    Priorite = 0
                };
            }
            public override BaseTabViewModel CreateContentTab()
            {
                ShowDialogSTA<OldMainWindow>(new OldMainViewModel());
                return null;
            }
        }
        public NewTaskViewModel()
            : base()
        {
            //if (!string.IsNullOrEmpty(App.Args.Section))
            //{
            //    AppCategoryEnum categorieChoisie = Sections.OfType<TaluvaCategorySection>().First(x => x.IsExpanded).Category;
            //    Enum.TryParse(App.Args.Section, out categorieChoisie);
            //    Sections.OfType<TaluvaCategorySection>().First(x => x.Category == categorieChoisie).IsExpanded = true;
            //}
            //else
            //    Sections.OfType<TaluvaCategorySection>().First(x => x.IsExpanded).IsExpanded = false;
        }

        protected override string IconBigImageName => "Taluva";

        public override string TabTitle => "Virtual Taluva";

        protected override TabSection CreateCategorySection(AppCategoryEnum cat)
        {
            return TaluvaCategorySection.CreateSection(cat);
        }

        protected override void AddAllFooterActions()
        {
            AddFooterAction( new ActionButtonSectionOld());
            base.AddAllFooterActions();
        }
    }
}
