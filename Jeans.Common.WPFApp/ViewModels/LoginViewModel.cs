using Jeans.Common.WPFApp.Commons;
using Jeans.Common.WPFApp.Models;
using System;
using System.Windows;

namespace Jeans.Common.WPFApp.ViewModels
{
    public class LoginViewModel : NotifyPropertyChangedBase
    {
        public LoginViewModel()
        {
            LoginModel = new LoginModel();

            LoginCommand = new CommandBase
            {
                RaiseExecuteChanged = new Action<object>(Login),
                RaiseCanExecuteChanged = new Func<object, bool>(LoginStatus)
            };

            ShowProgress = Visibility.Collapsed;
        }

        private Visibility _showProgress;
        /// <summary>
        /// 进度条
        /// </summary>
        public Visibility ShowProgress
        {
            get { return _showProgress; }
            set
            {
                _showProgress = value;
                base.RaisePropertyChanged();
            }
        }

        private string _errorMessage;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                base.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 登录模型
        /// </summary>
        public LoginModel LoginModel { get; set; }

        /// <summary>
        /// 登录命令
        /// </summary>
        public CommandBase LoginCommand { get; set; }

        private void Login(object o)
        {
            ErrorMessage = string.Empty;
            ShowProgress = Visibility.Visible;

            if (string.IsNullOrWhiteSpace(LoginModel.UserName))
            {
                ErrorMessage = "用户名不能为空";
                ShowProgress = Visibility.Collapsed;
                return;
            }

            if (string.IsNullOrWhiteSpace(LoginModel.PassWord))
            {
                ErrorMessage = "密码不能为空";
                ShowProgress = Visibility.Collapsed;
                return;
            }

            if (string.IsNullOrWhiteSpace(LoginModel.VerifyCode))
            {
                ErrorMessage = "验证码不能为空";
                ShowProgress = Visibility.Collapsed;
                return;
            }

            ErrorMessage = $"登录成功,UserName={LoginModel.UserName},Password={LoginModel.PassWord},VerifyCode={LoginModel.VerifyCode}";

            (o as Window).DialogResult = true;
        }

        private bool LoginStatus(object o)
        {
            return ShowProgress == Visibility.Collapsed;
        }
    }
}
