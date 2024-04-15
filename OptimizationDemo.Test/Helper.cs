using System.Collections;

namespace OptimizationDemo.Test
{
    internal static class Helper
    {
        public static object Clone(this object obj)
        {
            if (obj is null)
            {
                return null;
            }
            var type = obj.GetType();
            if (type.IsPrimitive
                    || type == typeof(string)
                    || type.IsValueType)
            {
                return obj;
            }

            var newObj = Activator.CreateInstance(obj.GetType());
            var properties = obj.GetType().GetProperties();
            foreach ( var property in properties )
            {
                if (property.PropertyType.IsPrimitive
                    || property.PropertyType == typeof(string)
                    || property.PropertyType.IsValueType)
                {
                    property.SetValue(newObj, property.GetValue(obj));
                }

                else if (property.PropertyType == typeof(DateOnly) || property.PropertyType == typeof(DateOnly?))
                {
                    DateOnly date = (DateOnly)property.GetValue(obj);
                    property.SetValue(newObj, DateOnly.FromDayNumber(date.DayNumber));
                }
                else if (property.PropertyType.IsGenericType 
                    && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var lst = Activator.CreateInstance(property.PropertyType);
                    var method = lst.GetType().GetMethod("Add");
                    var enumerable = property.GetValue(obj) as IEnumerable;
                    foreach ( var item in enumerable)
                    {
                        method.Invoke(lst, [item.Clone()]);
                    }

                    property.SetValue(newObj, lst);
                }
                else if (property.PropertyType.IsClass)
                {
                    property.SetValue(newObj, property.GetValue(obj).Clone());
                }
            }

            return newObj;
        }
    }
}
