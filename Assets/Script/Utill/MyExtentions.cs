using UnityEngine;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static void ifNotNull<T>(this T value, System.Action<T> onNotNull)
        {
            if (value == null)
            {
                Debug.LogWarning("value is Null");
                
                return;
            }

            onNotNull(value);
        }
    }
}
