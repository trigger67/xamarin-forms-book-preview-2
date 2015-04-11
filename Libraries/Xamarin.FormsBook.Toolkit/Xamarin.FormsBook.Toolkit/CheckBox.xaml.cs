﻿using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public partial class CheckBox : ContentView
    {
        public static readonly BindableProperty TextProperty = 
            BindableProperty.Create<CheckBox, string>(
                checkbox => checkbox.Text,  
                null, 
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((CheckBox)bindable).textLabel.Text = (string)newValue;
                });

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create<CheckBox, double>(
                checkbox => checkbox.FontSize,
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    CheckBox checkbox = (CheckBox)bindable;
                    checkbox.boxLabel.FontSize = newValue;
                    checkbox.textLabel.FontSize = newValue;
                });
                                    
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create<CheckBox, bool>(
                checkbox => checkbox.IsChecked,
                false,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    // Set the graphic.
                    CheckBox checkbox = (CheckBox)bindable;
                    checkbox.boxLabel.Text = newValue ? "\u2611" : "\u2610";

                    // Fire the event.
                    EventHandler<bool> eventHandler = checkbox.CheckedChanged;
                    if (eventHandler != null)
                    {
                        eventHandler(checkbox, newValue);
                    }
                });
                                                    
        public event EventHandler<bool> CheckedChanged;

        public CheckBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            set { SetValue(TextProperty, value); }
            get { return (string)GetValue(TextProperty); }
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }

        public bool IsChecked
        {
            set { SetValue(IsCheckedProperty, value); }
            get { return (bool)GetValue(IsCheckedProperty); }
        }

        // TapGestureRecognizer handler.
        void OnCheckBoxTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
        }
    }
}

