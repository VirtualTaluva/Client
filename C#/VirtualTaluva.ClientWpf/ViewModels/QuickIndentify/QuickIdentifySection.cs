using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight.CommandWpf;
using IconeIA.App.VieUtil.Enums;
using VirtualTaluva.ClientWpf.Attributes;

namespace VirtualTaluva.ClientWpf.ViewModels.QuickIndentify
{
    [AppCategory(AppCategoryEnum.Quick)]
    public class QuickIdentifySection : TaluvaCategorySection
    {
        private string m_Url = "127.0.0.1";
        private string m_Port = "42042";
        private string m_PlayerName = "Player";
        private RelayCommand m_OkCommand;
        public ICommand OkCommand => m_OkCommand ?? (m_OkCommand = new RelayCommand(OnOkCommand, ValidateOkCommand));

        public string Url
        {
            get { return m_Url; }
            set { Set(ref m_Url, value); }
        }

        public string Port
        {
            get { return m_Port; }
            set { Set(ref m_Port, value); }
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { Set(ref m_PlayerName, value); }
        }

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
            MainWindowViewModel.Instance.Connected = true;
            CreateNewTab(new LobbyViewModel(Url, int.Parse(Port), PlayerName));
        }
    }
}
