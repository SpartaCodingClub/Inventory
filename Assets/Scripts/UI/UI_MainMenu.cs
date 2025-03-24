public class UI_MainMenu : UI_Base
{
    private enum Children
    {
        Button_Status,
        Button_Inventory
    }

    protected override void Initialize()
    {
        base.Initialize();
        BindChildren(typeof(Children));
    }
}