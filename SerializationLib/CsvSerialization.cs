using System;
using System.Reflection;

namespace SerializationLib
{
    public static class CsvSerialization
    {
        public static string Serialize(object obj)
        {
            if (obj is null) throw new ArgumentNullException();

            var type = obj.GetType();
            var variables = type.GetFields();

            return FieldToString(variables, obj);
        }

        private static string FieldToString (FieldInfo[] fields, object obj)
        {
            var res = string.Empty;
            
            foreach (var variable in fields)
            {
                if (variable.FieldType.IsPrimitive)
                {
                    res += $"{variable.GetValue(obj)}|";
                }
                else
                {
                    if (variable.FieldType.IsEnum)
                    {
                        res += $"{variable.GetValue(obj)}|";
                    }
                    else
                    {
                        var variables = variable.FieldType.GetFields();
                        var temp = variable.GetValue(obj);
                        res += FieldToString(variables, temp);
                    }
                }
            }

            return res;
        }
    }
}