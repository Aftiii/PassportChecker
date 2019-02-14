using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using PassportChecker.Common.Enums;


namespace PassportChecker.Common.Helpers
{
    public class EnumHelper
    {
        //https://codereview.stackexchange.com/a/157981/20147
        public static string GetDescription(Enum input)
        {
            //Reflect on the enum type, get the enum member which we got passed in, only get the first, get the custom description attribute, return the description value.
            return input
            .GetType()
            .GetMember(input.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description;
        }
        public static List<KeyValuePair<int, string>> GetSelectList(Type enumType)
        {
            List<KeyValuePair<int, string>> genders = new List<KeyValuePair<int, string>>();
            if (enumType.IsEnum)
            {
                var genderValues = Enum.GetValues(enumType);
                foreach(int genderValue in genderValues)
                {
                    var member = Enum.Parse(enumType, genderValue.ToString());
                    KeyValuePair<int, string> gender = new KeyValuePair<int, string>(genderValue, GetDescription((Enum)member));
                    genders.Add(gender);
                }

                return genders;
            }
            return null;
        }
    }
}
