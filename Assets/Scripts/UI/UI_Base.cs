using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VInspector;

public abstract class UI_Base : MonoBehaviour
{
    #region Inspector  
#if UNITY_EDITOR
    [ShowInInspector]
    public State CurrentState
    {
        get
        {
            if (EditorApplication.isPlaying == false)
            {
                return State.Destroyed;
            }

            EditorUtility.SetDirty(this);
            return state;
        }
    }
#endif
    #endregion

    public bool IsDead { get { return state == State.Death || state == State.Destroyed; } }

    public event Action OnBirth;
    public event Action OnStand;
    public event Action OnDeath;
    public event Action OnDestoryed;

    protected CanvasGroup canvasGroup;

    private State state;

    private readonly SequenceHandler sequenceHandler = new();
    private readonly List<RectTransform> children = new();

    protected RectTransform Get(int index) => children[index];
    protected T Get<T>(int index) where T : Component => Get(index).GetComponent<T>();

    private void Awake() => Initialize();
    private void OnDestroy() => Deinitialize();
    protected void BindSequences(State type, params Func<Sequence>[] sequences) => sequenceHandler.Bind(type, sequences);

    protected virtual void Initialize()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        sequenceHandler.Initialize();
    }

    protected virtual void Deinitialize()
    {
        sequenceHandler.Deinitialize();
    }

    public virtual void Clear()
    {
        OnBirth = null;
        OnStand = null;
        OnDeath = null;
        OnDestoryed = null;
    }

    public virtual void Birth()
    {
        state = State.Birth;

        canvasGroup.interactable = false;
        sequenceHandler.Birth.Restart();

        OnBirth?.Invoke();
    }

    public virtual void Stand()
    {
        state = State.Stand;

        canvasGroup.interactable = true;
        sequenceHandler.Stand.Restart();

        OnStand?.Invoke();
    }

    public virtual void Death()
    {
        state = State.Death;

        canvasGroup.interactable = false;
        sequenceHandler.Stand.Pause();
        sequenceHandler.Death.Restart();

        OnDeath?.Invoke();
    }

    public virtual void Destroy()
    {
        state = State.Destroyed;

        canvasGroup.interactable = false;
        sequenceHandler.Stand.Pause();

        OnDestoryed?.Invoke();
        Destroy(gameObject);
    }

    protected void BindChildren(Type enumType)
    {
        var names = Enum.GetNames(enumType);
        foreach (var name in names)
        {
            RectTransform child = gameObject.FindComponent<RectTransform>(name);
            children.Add(child);
        }
    }
}