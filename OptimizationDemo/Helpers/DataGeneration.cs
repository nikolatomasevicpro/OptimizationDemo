namespace OptimizationDemo.Helpers
{
    public static class DataGeneration
    {
        private static Random _random = new Random();

        public static void InitRandom(int seed = 0) { _random = new Random(seed); }

        public static IEnumerable<T> GenerateDummyList<T>(int amount) where T : new()
        {
            var result = new T[amount];
            for (var i = 0; i < amount; i++)
            {
                result[i] = GenerateDummyObject<T>();
            }

            return result;
        }

        public static T GenerateDummyObject<T>() where T : new()
        {
            var dummy = new T();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                { 
                    var dummyValue = GenerateDummyValue(property.PropertyType);
                    property.SetValue(dummy, dummyValue);
                }
            }

            return dummy;
        }

        public static object GenerateDummyObject(Type type)
        {
            var dummy = Activator.CreateInstance(type);
            var properties = dummy.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var dummyValue = GenerateDummyValue(property.PropertyType);
                    property.SetValue(dummy, dummyValue);
                }
            }

            return dummy;
        }

        public static object GenerateDummyValue(Type type, bool isDefault = true)
        {
            var salt = _random.Next();

            if (type == typeof(Guid))
            {
                return Guid.NewGuid();
            }

            if (type == typeof(string))
            {
                return $"ooo{salt}";
            }

            if (type == typeof(int) || type == typeof(int?)
                || type == typeof(long) || type == typeof(long?))
            {
                return 98345 + salt;
            }

            if (type == typeof(float) || type == typeof(float?)
                || type == typeof(double) || type == typeof(double?))
            {
                return 1.2345 + salt;
            }

            if (type == typeof(bool) || type == typeof(bool?))
            {
                return isDefault;
            }

            if (type.IsEnum)
            {
                return isDefault ? 0 : 1;
            }

            if (type == typeof(DateOnly) || type == typeof(DateOnly?))
            {
                return DateOnly.FromDayNumber(salt % DateOnly.MaxValue.DayNumber);
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                var obj = Activator.CreateInstance(type);
                var method = obj.GetType().GetMethod("Add");
                var listType = type.GetGenericArguments()[0];
                method.Invoke(obj, [GenerateDummyValue(listType)]);
                return obj;
            }

            if (type.IsClass)
            {
                return GenerateDummyObject(type);
            }

            throw new NotSupportedException($"{type} is not supported");
        }
    }
}
