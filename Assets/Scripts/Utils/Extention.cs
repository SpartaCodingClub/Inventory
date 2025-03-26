using System;
using System.Collections.Generic;
using UnityEngine;

public static class Extention
{
    public static T FindComponent<T>(this GameObject gameObject, string name) where T : Component
    {
        return Utility.FindComponent<T>(gameObject, name);
    }

    public static List<T> FindComponents<T>(this GameObject gameObject, Type enumType) where T : Component
    {
        return Utility.FindComponents<T>(gameObject, enumType);
    }
}