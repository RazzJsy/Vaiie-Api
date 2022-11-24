namespace Casablanca_Common.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class FindAll
    {
        public List<T> Instances<T>(object value) where T : class
        {
            HashSet<object> exploredObjects = new();
            List<T> found = new();

            FindAllInstances(value, exploredObjects, found);

            return found;
        }

        private void FindAllInstances<T>(object value, HashSet<object> exploredObjects, List<T> found) where T : class
        {
            if (value == null)
            {
                return;
            }

            exploredObjects.Add(value);

            if (value is IEnumerable enumerable)
            {
                foreach (object item in enumerable)
                {
                    FindAllInstances(item, exploredObjects, found);
                }
            }
            else
            {
                if (value is T possibleMatch)
                {
                    found.Add(possibleMatch);
                }

                Type type = value.GetType();

                PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty);

                foreach (PropertyInfo property in properties)
                {
                    object propertyValue = property.GetValue(value, null);

                    FindAllInstances(propertyValue, exploredObjects, found);
                }
            }
        }
    }
}
