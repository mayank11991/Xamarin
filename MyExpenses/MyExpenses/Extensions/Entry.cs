using System.Windows.Input;
using Xamarin.Forms;

namespace MyExpenses.Extensions
{
    public class Entry : Xamarin.Forms.Entry
    {
        public Entry()
        {
            this.TextChanged += this.OnTextChanged;
        }

        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(Entry.TextChangedCommand), typeof(ICommand), typeof(Entry));

        public static readonly BindableProperty TextChangedCommandParameterProperty =
            BindableProperty.Create(nameof(Entry.TextChangedCommandParameter), typeof(object), typeof(Entry));

        public ICommand TextChangedCommand
        {
            get => (ICommand)this.GetValue(Entry.TextChangedCommandProperty);
            set => this.SetValue(Entry.TextChangedCommandProperty, (object)value);
        }

        public object TextChangedCommandParameter
        {
            get => this.GetValue(Entry.TextChangedCommandParameterProperty);
            set => this.SetValue(Entry.TextChangedCommandParameterProperty, value);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.TextChangedCommand == null ||
                 !this.TextChangedCommand.CanExecute(this.TextChangedCommandParameter))
                return;

            this.TextChangedCommand.Execute(this.TextChangedCommandParameter);
        }
    }
}
