using DG.Tweening;
using UnityEngine;

public class GameManager
{
    public Character Player { get; private set; } = new();

    public void Initialize()
    {
        DOTween.SetTweensCapacity(200, 125);
    }

    public void GameStart()
    {
        Player.SetName("이빠진호랑이");
        Player.SetLevel(1);
        Player.SetExp(0, 10);
        Player.SetStatus(0, 0, 0, 0);

        var bow = Resources.Load<ItemData>($"{Define.PATH_ITEM}/Item_Bow");
        Player.AddItem(bow);

        var armor = Resources.Load<ItemData>($"{Define.PATH_ITEM}/Item_Armor");
        Player.AddItem(armor);

        var potion = Resources.Load<ItemData>($"{Define.PATH_ITEM}/Item_Potion");
        Player.AddItem(potion);

        var ring = Resources.Load<ItemData>($"{Define.PATH_ITEM}/Item_Ring");
        Player.AddItem(ring);
    }
}