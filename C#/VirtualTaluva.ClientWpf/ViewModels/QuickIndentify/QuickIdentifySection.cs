using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using IconeIA.App.VieUtil.Enums;
using VirtualTaluva.ClientWpf.Attributes;

namespace VirtualTaluva.ClientWpf.ViewModels.QuickIndentify
{
    [AppCategory(AppCategoryEnum.Quick)]
    public class QuickIdentifySection : TaluvaCategorySection
    {
        private RelayCommand m_OkCommand;
        public ICommand OkCommand => m_OkCommand ?? (m_OkCommand = new RelayCommand(OnOkCommand, ValidateOkCommand));

        public QuickIdentifySection()
            : base(AppCategoryEnum.Quick)
        {
        }

        private bool ValidateOkCommand()
        {
            return true;
        }
        private void OnOkCommand()
        {
        }
    }
}
