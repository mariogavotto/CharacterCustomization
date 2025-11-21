using System.Collections.Generic;
using UnityEngine;
using System;

public static class ServiceLocator
{
    private static Dictionary<Type, object> _services = new ();

    public static void Register<T>(T service) where T : class
    {
        Type type = typeof(T);
        if (_services.ContainsKey(type))
        {
            Debug.LogError("Error service is already added");
            return;
        }

        _services[type] = service;
    }

    public static T Get<T>() where T : class
    {
        if (_services.TryGetValue(typeof(T),out var service))
        {
            return (T) service;
        }
        throw new Exception($"Services {typeof(T)} is not registered");

    }
}
