﻿using System;
using System.Globalization;
using System.Windows.Data;
using WDE.Common.Managers;

namespace WoWDatabaseEditorCore.WPF.Views.Helpers
{
    public class ActiveDocumentConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IDocument)
                return value;

            return null;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IDocument)
                return value;

            return null;
        }
    }
}