﻿using System.ComponentModel;
using System.Reflection;

namespace Supermarket.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this Enum @enum) 
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());

            if (info == null)
            { 
                return @enum.ToString();
            }

            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes?[0].Description ?? @enum.ToString();
        }

    }
}
