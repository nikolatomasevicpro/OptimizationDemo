using OptimizationDemo.Helpers;
using System.Reflection;

namespace OptimizationDemo.Test.Comparers
{
    internal abstract class BaseComparerTest<T, TComparer> 
        where TComparer : IEqualityComparer<T>, new()
        where T : new()
    {
        [Test]
        public void Comparer_Should_Properly_Compare()
        {
            DataGeneration.InitRandom(420);
            var comparer = new TComparer();
            var obj1 = DataGeneration.GenerateDummyObject<T>();

            Assert.That(comparer.Equals(obj1, obj1), Is.True, "Same object should be equal");

            var obj2 = (T)obj1.Clone();
            Assert.That(comparer.Equals(obj1, obj2), Is.True, "Objects with same property values should be equal");

            var properties = obj1.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    AssertDifference(comparer, obj1, property);
                }
            }
        }

        private static void AssertDifference<T>(IEqualityComparer<T> comparer, T original, PropertyInfo property)
        {
            var clone = (T)original.Clone();
            property.SetValue(clone, DataGeneration.GenerateDummyValue(property.PropertyType, false));

            Assert.That(comparer.Equals(original, clone), Is.False, $"Should, not be equal - {property.Name}");
        }
    }
}
