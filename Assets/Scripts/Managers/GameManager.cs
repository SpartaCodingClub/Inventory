using DG.Tweening;

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
        Player.SetStatus(256, 91, 40, 34);
    }
}