using Metro.LL.Common;

namespace LL.ApplicationLifeCycle.ViewModels
{
    public class DashboardViewModel : BaseViewModel, IResumable
    {
        public DashboardViewModel()
        {
            PageTitle = "Learning to use Application Life Cycles";
        }

        public void Resume()
        {
            PageTitle = "Learning to use Application Life Cycles -- From Resume";
        }
    }

    public interface IResumable
    {
        void Resume();
    }
}
