using DG.Tweening;

public class UI_Status : UI_Base
{
    #region Sequences
    private Sequence Status_Birth()
    {
        var child = Get((int)Children.Status);

        return DOTween.Sequence()
            .Append(child.DOAnchorPosX(666.5551f, 0.5f).From().SetEase(Ease.OutBack).OnComplete(Stand));
    }

    private Sequence Status_Death()
    {
        var child = Get((int)Children.Status);

        return DOTween.Sequence()
            .Append(child.DOAnchorPosX(666.5551f, 0.5f).SetEase(Ease.InBack));
    }
    #endregion

    private enum Children
    {
        Status,
        Text_Attack,
        Text_Defense,
        Text_Health,
        Text_Critical,
        Button_Back
    }

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));

        BindSequences(State.Birth, Status_Birth);
        BindSequences(State.Death, Status_Death);
    }
}