using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Metro.LL.Common
{
    public static class WindowManager
    {
        private static IList<UIElement> _backStack = new List<UIElement>();

        public static void NavigateTo(UserControl page)
        {
            if (Window.Current.Content != null)
            {
                BackStack.Add(Window.Current.Content);
            }

            Window.Current.Content = page;
            Window.Current.Activate();
        }

        public static IList<UIElement> BackStack { get { return _backStack; } }

    }
}
