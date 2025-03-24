public class UI_Inventory : UI_Base
{
    private enum Children
    {
        Content,
        Button_Back
    }

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));
    }
}