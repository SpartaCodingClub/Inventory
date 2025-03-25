using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventorySlot : UI_Base, IPointerClickHandler
{
    private enum Children
    {
        Icon,
        Equipment
    }

    public bool IsEmpty { get; private set; } = true;

    private bool isEquip;
    private ItemData item;

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));
    }

    public void RefreshUI()
    {
        var icon = Get<Image>((int)Children.Icon);
        icon.sprite = item.Icon;
        icon.gameObject.SetActive(true);

        IsEmpty = false;
        Get((int)Children.Equipment).gameObject.SetActive(isEquip);
    }

    public void SetItem(ItemData item)
    {
        this.item = item;
        RefreshUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsEmpty)
        {
            return;
        }

        if (isEquip)
        {
            Managers.Game.Player.Unequip(item);
        }
        else
        {
            Managers.Game.Player.Equip(item);
        }

        isEquip = !isEquip;
        RefreshUI();
    }
}