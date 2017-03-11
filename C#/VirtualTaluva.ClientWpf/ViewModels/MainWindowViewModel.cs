using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Shell;
using System.Windows.Threading;
using Com.Ericmas001.Windows.ViewModels;
using VirtualTaluva.Client.Protocol;

namespace VirtualTaluva.ClientWpf.ViewModels
{
    public class MainWindowViewModel : TabControlViewModel
    {
        private readonly NewTaskViewModel disconnectedTab = new NewTaskViewModel();
        private readonly Dispatcher currentDispatcher = Dispatcher.CurrentDispatcher;
        private LobbyTcpClientQuickMode m_Server;

        public LobbyTcpClientQuickMode Server
        {
            get { return m_Server; }
            set
            {
                Set(ref m_Server, value);
            }
        }

        public bool Connected
        {
            get { return m_Connected; }
            set
            {
                if (m_Connected && !value)
                {
                    if (m_Server != null && m_Server.IsConnected)
                        m_Server.Disconnect();
                    m_Server = null;
                    currentDispatcher.Invoke(() => Tabs.Clear());
                    currentDispatcher.Invoke(() => Tabs.Add(disconnectedTab));
                    SelectedTab = disconnectedTab;
                }
                else if (!m_Connected && value)
                {
                    currentDispatcher.Invoke(() => Tabs.Clear());
                }
                m_Connected = value;
            }
        }

        private static MainWindowViewModel m_Instance;
        public MainWindowViewModel()
        {
            m_Instance = this;
            AddTab(disconnectedTab);
        }
        [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
        public static bool ShouldWindowBlink
        {
            set
            {
                bool shouldBlink = value && !m_Instance.IsWindowActive;
                m_Instance.ProgressState = shouldBlink ? TaskbarItemProgressState.Normal : TaskbarItemProgressState.None;
                m_Instance.ProgressValue = shouldBlink ? 100 : 0;
                m_Instance.RaisePropertyChanged("ProgressState");
                m_Instance.RaisePropertyChanged("ProgressValue");
            }
        }

        private bool m_IsWindowActive;
        private bool m_Connected = false;

        public bool IsWindowActive
        {
            get { return m_IsWindowActive; }
            set
            {
                m_IsWindowActive = value;
                if (m_IsWindowActive && ProgressState == TaskbarItemProgressState.Normal)
                    ShouldWindowBlink = false;
            }
        }

        public TaskbarItemProgressState ProgressState { get; set; }

        public int ProgressValue { get; set; }
        protected override bool KeepNewTab => false;

        public static MainWindowViewModel Instance => m_Instance;

        protected override NewTabViewModel CreateNewTab()
        {
            return null;
        }
    }
}
