using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : UI_Base
{
    #region Sequences
    private Sequence Inventory_Birth()
    {
        var child = Get((int)Children.Inventory);

        return DOTween.Sequence()
            .Append(child.DOAnchorPosX(600.0f, 0.5f).From().SetEase(Ease.OutBack).OnComplete(Stand));
    }

    private Sequence Inventory_Death()
    {
        var child = Get((int)Children.Inventory);

        return DOTween.Sequence()
            .Append(child.DOAnchorPosX(600.0f, 0.3f));
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
        Inventory,
        Content,
        Button_Back
    }

    private readonly List<UI_InventorySlot> slots = new();

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));

        BindSequences(State.Birth, Inventory_Birth);
        BindSequences(State.Death, Inventory_Death);

        Get<Button>((int)Children.Button_Back).onClick.AddListener(Button_Back);

        var content = Get((int)Children.Content);
        for (int i = 0; i < Define.INVENTORY_COUNT; i++)
        {
            var slotPrefab = Resources.Load<GameObject>(nameof(UI_InventorySlot));
            var slotObject = Instantiate(slotPrefab, content);
            var slot = slotObject.GetComponent<UI_InventorySlot>();
            slots.Add(slot);
        }
    }

    public void RefreshUI()
    {

    }
}