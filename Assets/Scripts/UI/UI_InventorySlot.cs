public class UI_InventorySlot : UI_Base
{
    private enum Children
    {
        Icon,
        Equipment
    }

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));
    }
}