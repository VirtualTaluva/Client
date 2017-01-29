using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using IconeIA.App.VieUtil.Enums;
using VirtualTaluva.ClientWpf.Attributes;

namespace VirtualTaluva.ClientWpf.ViewModels.SignInRegistered
{
    [AppCategory(AppCategoryEnum.SignIn)]
    public class SignInRegisteredSection : TaluvaCategorySection
    {
        private RelayCommand m_OkCommand;
        public ICommand OkCommand => m_OkCommand ?? (m_OkCommand = new RelayCommand(OnOkCommand, ValidateOkCommand));

        public SignInRegisteredSection()
            : base(AppCategoryEnum.SignIn)
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
