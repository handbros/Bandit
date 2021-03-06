﻿using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bandit.Converters
{
    /// <summary>
    /// ListView 객체의 각 Item을(를) 순서를 지정하는 문자열로 변환해주는 Converter 입니다.
    /// </summary>
    [ValueConversion(typeof(ListView), typeof(string))]
    public class IndexConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
            {
                throw new InvalidOperationException("The target must be a string!");
            }

            ListViewItem item = (ListViewItem)value;
            ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            int index = listView.ItemContainerGenerator.IndexFromContainer(item);
            return $"{index+1}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
