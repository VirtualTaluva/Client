using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using IconeIA.App.VieUtil.Enums;
using VirtualTaluva.ClientWpf.Attributes;

namespace VirtualTaluva.ClientWpf.ViewModels.Register
{
    [AppCategory(AppCategoryEnum.Register)]
    public class RegisterSection : TaluvaCategorySection
    {
        private RelayCommand m_OkCommand;
        public ICommand OkCommand => m_OkCommand ?? (m_OkCommand = new RelayCommand(OnOkCommand, ValidateOkCommand));

        public RegisterSection()
            : base(AppCategoryEnum.Register)
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
