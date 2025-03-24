public class UI_InventorySlot : UI_Base
{
    private enum Children
    {

    }

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));
    }
}