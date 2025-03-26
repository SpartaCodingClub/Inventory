using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class Utility
{
    public static T FindComponent<T>(GameObject gameObject, string name) where T : Component
    {
        var components = gameObject.GetComponentsInChildren<T>(true);
        foreach (var component in components)
        {
            if (component.name.Equals(name))
            {
                return component;
            }
        }

        Debug.LogWarning($"Failed to FindComponent<{typeof(T).Name}>({gameObject.name}, {name})");
        return null;
    }

    public static List<T> FindComponents<T>(GameObject gameObject, Type enumType) where T : Component
    {
        Dictionary<string, T> components = new();

        var children = gameObject.GetComponentsInChildren<T>(true);
        foreach (var child in children)
        {
            components.TryAdd(child.name, child);
        }

        var names = Enum.GetNames(enumType);
        return names.Where(components.ContainsKey).Select(name => components[name]).ToList();
    }

    public static Sequence RecyclableSequence()
    {
        return DOTween.Sequence().Pause().SetAutoKill(false);
    }
}