using Jeans.Common.WPFApp.Commons;
using Jeans.Common.WPFApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Jeans.Common.WPFApp.ViewModels
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private string _searchText;
        /// <summary>
        /// 搜索文本
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                RaisePropertyChanged();
            }
        }

        private FrameworkElement _mainContent;
        /// <summary>
        /// 内容
        /// </summary>
        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set
            {
                _mainContent = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 菜单切换命令
        /// </summary>
        public CommandBase NavChangeCommand { get; set; }

        public MainViewModel()
        {
            NavChangeCommand = new CommandBase();
            NavChangeCommand.RaiseExecuteChanged = new Action<object>(NavChangeCommandExecute);
            NavChangeCommand.RaiseCanExecuteChanged = new Func<object, bool>(NavChangeCommandCanExecute);

            NavChangeCommandExecute("HomeView");
        }


        private void NavChangeCommandExecute(object obj)
        {
            var type = Type.GetType("Jeans.Common.WPFApp.Views." + obj.ToString());
            var ctor = type?.GetConstructor(Type.EmptyTypes);
            var o = ctor?.Invoke(null);
            if (o != null)
            {
                MainContent = (FrameworkElement)o;
            }
            else
            {
                MainContent = null;
            }
        }

        private bool NavChangeCommandCanExecute(object obj)
        {
            return true;
        }
    }
}
