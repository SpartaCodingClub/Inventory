using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    private Transform transform;

    public UI_MainMenu MainMenu { get; private set; }
    public UI_Status Status { get; private set; }
    public UI_Inventory Inventory { get; private set; }

    public void Initialize()
    {
        transform = new GameObject(nameof(UIManager), typeof(StandaloneInputModule)).transform;
        transform.SetParent(Managers.Instance.transform);

        MainMenu = Object.FindObjectOfType<UI_MainMenu>();

        Status = Object.FindObjectOfType<UI_Status>();
        Status.gameObject.SetActive(false);

        Inventory = Object.FindObjectOfType<UI_Inventory>();
        Inventory.gameObject.SetActive(false);
    }
}