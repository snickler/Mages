﻿namespace Mages.Core.Runtime.Functions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The collection of all type function creators.
    /// </summary>
    public static class TypeFunctions
    {
        private static Dictionary<Type, Func<Object, Function>> _getters = new Dictionary<Type, Func<Object, Function>>
        {
            { typeof(Double[,]), obj => ((Double[,])obj).Getter },
            { typeof(String), obj => ((String)obj).Getter },
            { typeof(IDictionary<String, Object>), obj => ((IDictionary<String, Object>)obj).Getter },
        };

        /// <summary>
        /// Registers the provided getter function.
        /// </summary>
        /// <typeparam name="T">The type of the object to extend.</typeparam>
        /// <param name="getter">The getter function to register.</param>
        public static void RegisterGetter<T>(Func<T, Function> getter)
        {
            _getters[typeof(T)] = val => getter((T)val);
        }

        /// <summary>
        /// Tries to find the named getter.
        /// </summary>
        /// <param name="instance">The object context.</param>
        /// <param name="function">The potentially found getter function.</param>
        /// <returns>True if the getter could be found, otherwise false.</returns>
        public static Boolean TryFindGetter(Object instance, out Function function)
        {
            var type = instance.GetType();

            foreach (var getter in _getters)
            {
                if (getter.Key.IsAssignableFrom(type))
                {
                    function = getter.Value.Invoke(instance);
                    return true;
                }
            }

            function = null;
            return false;
        }
    }
}