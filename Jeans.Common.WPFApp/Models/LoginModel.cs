using Jeans.Common.WPFApp.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.Common.WPFApp.Models
{
    public class LoginModel : NotifyPropertyChangedBase
    {
        private string _userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                base.RaisePropertyChanged();
            }
        }

        private string _passWord;
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
                base.RaisePropertyChanged();
            }
        }

        private string _verifyCode;
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode
        {
            get { return _verifyCode; }
            set
            {
                _verifyCode = value;
                base.RaisePropertyChanged();
            }
        }
    }
}
