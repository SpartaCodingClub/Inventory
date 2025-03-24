using DG.Tweening;
using UnityEngine.UI;

public class UI_MainMenu : UI_Base
{
    #region Sequences
    private Sequence Right_Birth()
    {
        var child = Get((int)Children.Right);

        return DOTween.Sequence()
            .Append(child.DOAnchorPosX(400.0f, 0.5f).From().SetEase(Ease.OutBack).OnComplete(Stand));
    }

    private Sequence Right_Death()
    {
        var child = Get((int)Children.Right);

        return DOTween.Sequence()
            .Append(child.DOAnchorPosX(400.0f, 0.5f).SetEase(Ease.InBack));
    }
    #endregion
    #region Events
    private void Button_Status()
    {
        Death();
        Managers.UI.Status.Birth();
    }

    private void Button_Inventory()
    {
        Death();
        Managers.UI.Inventory.Birth();
    }
    #endregion

    private enum Children
    {
        Right,
        Button_Status,
        Button_Inventory
    }

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));

        BindSequences(State.Birth, Right_Birth);
        BindSequences(State.Death, Right_Death);

        Get<Button>((int)Children.Button_Status).onClick.AddListener(Button_Status);
        Get<Button>((int)Children.Button_Inventory).onClick.AddListener(Button_Inventory);

        Birth();
    }
}