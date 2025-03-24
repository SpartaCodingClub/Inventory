using DG.Tweening;
using System;
using System.Collections.Generic;
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

    public static Component[] FindComponents(GameObject gameObject, Type enumType)
    {
        List<Component> components = null;

        var names = Enum.GetNames(enumType);
        var children = gameObject.GetComponentsInChildren<Transform>(true);

        foreach (var name in names)
        {
            foreach (var child in children)
            {
                if (child.name != name)
                {
                    continue;
                }

                components.Add(child);
            }
        }

        return components.ToArray();
    }

    public static Sequence RecyclableSequence()
    {
        return DOTween.Sequence().Pause().SetAutoKill(false);
    }
}