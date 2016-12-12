using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Nager.Date.Utils
{
    // Extensions useful for all projects
    public static class Extensions
    {
        public static bool IsInt32(this string numberStr)
        {
            if (string.IsNullOrWhiteSpace(numberStr)) return false;

            int test;
            return int.TryParse(numberStr, out test);
        }

        public static string GetDescription(this System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static T GetEnumValueOfDescription<T>(this string value) where T : struct, IConvertible    //limit to enums
        {
            if (typeof(T).IsEnum)
            {
                string[] names = System.Enum.GetNames(typeof(T));
                foreach (string name in names)
                {
                    if (GetDescription((System.Enum)System.Enum.Parse(typeof(T), name)).Equals(value))
                    {
                        return (T)System.Enum.Parse(typeof(T), name);
                    }
                }
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }

        public static List<KeyValuePair<string, string>> ToList(this Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new Exception("Type should be an Enum");
            }

            List<KeyValuePair<string, string>> res = new List<KeyValuePair<string, string>>();
            foreach (var v in System.Enum.GetValues(enumType))
            {
                res.Add(new KeyValuePair<string, string>(v.ToString(), (v as System.Enum).GetDescription()));
            }

            return res;
        }

        public static T GetValueForSection<T>(this DataTable data, string sectionNr, string dataType = null)
        {
            throw new NotImplementedException();
        }

        public static string GetLabelForSection(this DataTable data, string sectionNr)
        {
            return "";
        }

        public static string SanitizeString(this string data)
        {
            return System.Text.RegularExpressions.Regex.Replace(data, "(^[0-9]|[^a-zA-Z0-9_])", "_");
        }

        public static bool IsNullOrEmpty(this IEnumerable collection)
        {
            if (collection == null) return true;

            while (collection.GetEnumerator().MoveNext())
            {
                return false;
            }

            return true;
        }
    }
}
