using System.Windows.Controls;
using System.Windows;

namespace POSAppWPF
{
    public class MonitorPasswordBoxProperty : BaseAttachedProperty<MonitorPasswordBoxProperty, bool>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                RoutedEventHandler onLoad = null;

                onLoad = (ss, ee) =>
                {
                    passwordBox.Loaded -= onLoad;
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                };

                passwordBox.Loaded += onLoad;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasPassword.SetValue((PasswordBox)sender, ((PasswordBox)sender).Password.Length > 0);
        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }

    public class HasPassword : BaseAttachedProperty<HasPassword, bool>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }
}
