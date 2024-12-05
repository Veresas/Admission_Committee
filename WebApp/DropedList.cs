﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Reflection;

namespace WebApp
{
    public static class DropedList
    {
        public static IEnumerable<SelectListItem> GetEnumDescriptions(Type enumType)
        {
            var selectListItems = new List<SelectListItem>();

            foreach (Enum value in Enum.GetValues(enumType))
            {
                var descriptionText = value.GetType()
                                           .GetField(value.ToString())?
                                           .GetCustomAttribute<DescriptionAttribute>()?.Description
                                           ?? value.ToString();

                string valueString = Convert.ToString(Convert.ChangeType(value, enumType.GetEnumUnderlyingType()));


                selectListItems.Add(new SelectListItem { Text = descriptionText, Value = valueString });
            }

            return selectListItems;
        }
    }
}
