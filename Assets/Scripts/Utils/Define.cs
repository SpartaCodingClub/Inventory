public enum State
{
    Destroyed,
    Birth,
    Stand,
    Death
}

public enum ItemType
{
    Weapon,
    Armor,
    Ring,
    Consumable
}

public class Define
{
    public static readonly int INVENTORY_COUNT = 12;

    public const string PATH_ITEM = "Items";
    public const string PATH_UI = "UI";
}