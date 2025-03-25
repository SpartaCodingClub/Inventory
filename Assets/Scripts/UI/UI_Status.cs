using DG.Tweening;
using TMPro;
using UnityEngine.UI;

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
            .Append(child.DOAnchorPosX(666.5551f, 0.3f));
    }
    #endregion
    #region Events
    private void Button_Back()
    {
        Death();
        Managers.UI.MainMenu.Birth();
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

        Get<Button>((int)Children.Button_Back).onClick.AddListener(Button_Back);
    }

    public void RefreshUI(Character player)
    {
        Get<TMP_Text>((int)Children.Text_Attack).text = player.Attack.ToString();
        Get<TMP_Text>((int)Children.Text_Defense).text = player.Defense.ToString();
        Get<TMP_Text>((int)Children.Text_Health).text = player.Health.ToString();
        Get<TMP_Text>((int)Children.Text_Critical).text = player.Critical.ToString();
    }
}