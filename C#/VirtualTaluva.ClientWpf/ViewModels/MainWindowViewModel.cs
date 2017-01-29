using System.Diagnostics.CodeAnalysis;
using System.Windows.Shell;
using Com.Ericmas001.Windows.ViewModels;

namespace VirtualTaluva.ClientWpf.ViewModels
{
    public class MainWindowViewModel : TabControlViewModel
    {
        private static MainWindowViewModel m_Instance;
        public MainWindowViewModel()
        {
            m_Instance = this;
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
        protected override bool KeepNewTab => true;

        protected override NewTabViewModel CreateNewTab()
        {
            return new NewTaskViewModel();
        }
    }
}
