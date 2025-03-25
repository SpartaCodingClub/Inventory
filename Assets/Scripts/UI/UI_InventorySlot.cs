using UnityEngine.UI;

public class UI_InventorySlot : UI_Base
{
    private enum Children
    {
        Icon,
        Equipment
    }

    public bool IsEmpty { get; private set; } = true;

    private ItemData itemData;

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));
    }

    public void RefreshUI()
    {
        Get<Image>((int)Children.Icon).sprite = itemData.Icon;
        IsEmpty = false;

        Managers.UI.Inventory.RefreshUI();
    }

    public void SetItem(ItemData itemData)
    {
        this.itemData = itemData;
        RefreshUI();
    }
}