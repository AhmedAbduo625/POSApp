using System.Windows;

namespace POSAppWPF
{
    public abstract class BaseAttachedProperty<Child, Property> where Child : BaseAttachedProperty<Child, Property>, new()
    {
        public static Child Instance { get; set; } = new Child();

        public static Property GetValue(DependencyObject obj)
        {
            return (Property)obj.GetValue(ValueProperty);
        }

        public static void SetValue(DependencyObject obj, Property value)
        {
            obj.SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Child, Property>), new UIPropertyMetadata(default(Property), OnValueChanged, OnValueUpdated));

        private static object OnValueUpdated(DependencyObject d, object baseValue)
        {
            Instance.ValueUpdatedHandler(d, baseValue);
            return baseValue;
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.ValueChangedHandler(d, e);
        }

        public abstract void ValueUpdatedHandler(DependencyObject d, object baseValue);
        public abstract void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e);
    }
}
