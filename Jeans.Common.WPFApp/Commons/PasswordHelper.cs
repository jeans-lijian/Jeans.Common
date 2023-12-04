using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Jeans.Common.WPFApp.Commons
{
    public class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPasswordPropertyChanged)));

        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

                if (_isUpdating == false)
                {
                    passwordBox.Password = e.NewValue == null ? string.Empty : e.NewValue.ToString();
                }

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        public static string GetPassword(DependencyObject d)
        {
            return (string)d.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }


        private static bool _isUpdating = false;

        public static readonly DependencyProperty attachProperty = DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttachPropertyChanged)));

        private static void OnAttachPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                _isUpdating = true;
                SetPassword(passwordBox, passwordBox.Password);
                _isUpdating = false;
            }
        }

        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(attachProperty);
        }

        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(attachProperty, value);
        }
    }
}
