using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    private Transform transform;

    private UI_MainMenu mainMenu;
    private UI_Status status;
    private UI_Inventory inventory;

    public void Initialize()
    {
        transform = new GameObject(nameof(UIManager), typeof(StandaloneInputModule)).transform;
        transform.SetParent(Managers.Instance.transform);


    }
}