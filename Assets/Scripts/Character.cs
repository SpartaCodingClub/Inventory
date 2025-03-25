using System.Collections.Generic;

public class Character
{
    public string Name { get; private set; }

    public int Level { get; private set; }
    public int Exp { get; private set; }
    public int MaxExp { get; private set; }

    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Critical { get; private set; }

    public void SetName(string name) => Name = name;
    public void SetLevel(int level) => Level = level;

    public List<ItemData> Inventory { get; private set; } = new();

    public void SetExp(int exp, int maxExp)
    {
        Exp = exp;
        MaxExp = maxExp;

        Managers.UI.MainMenu.RefreshUI(this);
    }

    public void SetStatus(int attack, int defense, int health, int critical)
    {
        Attack = attack;
        Defense = defense;
        Health = health;
        Critical = critical;

        Managers.UI.Status.RefreshUI(this);
    }

    public void AddItem(ItemData item)
    {
        Managers.UI.Inventory.AddItem(item);
    }

    public void Equip(ItemData item)
    {
        switch (item.Type)
        {
            case ItemType.Weapon:
                Attack += item.Value;
                break;
            case ItemType.Armor:
                Defense += item.Value;
                break;
            case ItemType.Ring:
                Critical += item.Value;
                break;
            case ItemType.Consumable:
                Health += item.Value;
                break;
        }

        Managers.UI.Status.RefreshUI(this);
    }

    public void Unequip(ItemData item)
    {
        switch (item.Type)
        {
            case ItemType.Weapon:
                Attack -= item.Value;
                break;
            case ItemType.Armor:
                Defense -= item.Value;
                break;
            case ItemType.Ring:
                Critical -= item.Value;
                break;
            case ItemType.Consumable:
                Health -= item.Value;
                break;
        }

        Managers.UI.Status.RefreshUI(this);
    }
}