public class UI_Status : UI_Base
{
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
    }
}