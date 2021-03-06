﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View
{
    public class SpeciesToTerroristsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var species = value as string;
            if (species == "hunter")
            {
                return "fbi.png";
            }
            else if (species == "prey")
            {
                return "osamachan.png";
            }
            else if (species == "bomb")
            {
                return "bomb.png";
            
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
