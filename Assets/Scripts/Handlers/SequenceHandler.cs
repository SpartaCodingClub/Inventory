using DG.Tweening;
using System;
using UnityEngine;

public class SequenceHandler
{
    public Sequence Birth { get; private set; }
    public Sequence Stand { get; private set; }
    public Sequence Death { get; private set; }

    public void Initialize()
    {
        Birth = Utility.RecyclableSequence();
        Stand = Utility.RecyclableSequence().SetLoops(-1);
        Death = Utility.RecyclableSequence();
    }

    public void Deinitialize()
    {
        Birth.Kill();
        Stand.Kill();
        Death.Kill();
    }

    public void Bind(State type, params Func<Sequence>[] sequences)
    {
        // Sequence 배열은 Join으로 연결
        Sequence sequence = sequences[0]();
        for (int i = 1; i < sequences.Length; i++)
        {
            sequence.Join(sequences[i]());
        }

        // Bind 재호출은 Append로 연결
        switch (type)
        {
            case State.Destroyed:
                Debug.LogWarning($"Failed to BindSequences({type})");
                break;
            case State.Birth:
                Birth.Append(sequence);
                break;
            case State.Stand:
                Stand.Append(sequence);
                break;
            case State.Death:
                Death.Append(sequence);
                break;
        }
    }
}