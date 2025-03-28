using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Sample
{
    [TemplatePart(Name = "UpButtonElement", Type = typeof(RepeatButton))]
    [TemplatePart(Name = "DownButtonElement", Type = typeof(RepeatButton))]
    [TemplateVisualState(Name = "Positive", GroupName = "ValueStates")]
    [TemplateVisualState(Name = "Negative", GroupName = "ValueStates")]
    [TemplateVisualState(Name = "Focused", GroupName = "FocusedStates")]
    [TemplateVisualState(Name = "Unfocused", GroupName = "FocusedStates")]
    [TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
    [TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
    public class NumericUpDown : Control
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", 
            typeof(int), 
            typeof(NumericUpDown),
            new PropertyMetadata(new PropertyChangedCallback(ValueChangedCallback)));

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
            "ValueChanged", 
            RoutingStrategy.Direct,
            typeof(ValueChangedEventHandler), 
            typeof(NumericUpDown));

        private RepeatButton upButtonElement;
        private RepeatButton downButtonElement;

        public NumericUpDown()
        {
            DefaultStyleKey = typeof(NumericUpDown);
            this.IsTabStop = true;
            this.IsEnabledChanged += new DependencyPropertyChangedEventHandler(this.OnIsEnabledChanged);
        }

        public event ValueChangedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            this.UpButtonElement = this.GetTemplateChild("UpButton") as RepeatButton;
            this.DownButtonElement = this.GetTemplateChild("DownButton") as RepeatButton;

            this.UpdateStates(false);
        }

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            // Raise the ValueChanged event so applications can be alerted
            // when Value changes.
            this.RaiseEvent(e);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.Focus();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            this.UpdateStates(true);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            this.UpdateStates(true);
        }

        private static void ValueChangedCallback(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            NumericUpDown ctl = (NumericUpDown)obj;
            int newValue = (int)args.NewValue;

            // Call UpdateStates because the Value might have caused the
            // control to change ValueStates.
            ctl.UpdateStates(true);

            // Call OnValueChanged to raise the ValueChanged event.
            ctl.OnValueChanged(new ValueChangedEventArgs(
                NumericUpDown.ValueChangedEvent,
                newValue));
        }

        private RepeatButton DownButtonElement
        {
            get
            {
                return this.downButtonElement;
            }

            set
            {
                if (this.downButtonElement != null)
                {
                    this.downButtonElement.Click -=
                        new RoutedEventHandler(this.downButtonElement_Click);
                }

                this.downButtonElement = value;

                if (this.downButtonElement != null)
                {
                    this.downButtonElement.Click +=
                        new RoutedEventHandler(this.downButtonElement_Click);
                }
            }
        }

        private RepeatButton UpButtonElement
        {
            get
            {
                return upButtonElement;
            }

            set
            {
                if (upButtonElement != null)
                {
                    upButtonElement.Click -=
                        new RoutedEventHandler(upButtonElement_Click);
                }
                upButtonElement = value;

                if (upButtonElement != null)
                {
                    upButtonElement.Click +=
                        new RoutedEventHandler(upButtonElement_Click);
                }
            }
        }

        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.UpdateStates(true); ;
        }

        private void UpdateStates(bool useTransitions)
        {
            if (Value >= 0)
            {
                VisualStateManager.GoToState(this, "Positive", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Negative", useTransitions);
            }

            if (IsFocused)
            {
                VisualStateManager.GoToState(this, "Focused", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Unfocused", useTransitions);
            }

            if (false == this.IsEnabled)
            {
                VisualStateManager.GoToState(this, "Disabled", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", useTransitions);
            }
        }

        private void downButtonElement_Click(object sender, RoutedEventArgs e)
        {
            this.Value--;
        }

        private void upButtonElement_Click(object sender, RoutedEventArgs e)
        {
            this.Value++;
        }
    }


    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

    public class ValueChangedEventArgs : RoutedEventArgs
    {
        private int _value;

        public ValueChangedEventArgs(RoutedEvent id, int num)
        {
            this._value = num;
            this.RoutedEvent = id;
        }

        public int Value
        {
            get { return this._value; }
        }
    }
}