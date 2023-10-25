using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private float slotSize = 50;
    public Inventory inventory { get; set; }
    public ManagerInventory managerInventory { get; set; }
    public Sprite buttonImage;
    private Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    public void AddGraphics()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child != itemSlotTemplate)
                Destroy(child.gameObject);
        }
        var x = 0;
        foreach (Item item in inventory.GetItems())
        {
            RectTransform slotRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            DrawCell(slotRectTransorm,
                new Vector2(12 + 1.1f * x * slotSize, -1 * slotSize),
                () => inventory.GiveItem(item),
                () => inventory.GiveItem(item),
                item.image);
            x++;
        }
        RectTransform buttonRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        DrawCell(buttonRectTransorm,
            new Vector2(3f * slotSize, -1 * slotSize),
            () => { managerInventory.CheckWin(); },
            () => { managerInventory.CheckWin(); },
            buttonImage);
    }

    public void DrawCell(RectTransform rt, Vector2 vector, Action leftClick, Action rightClick, Sprite image)
    {
        rt.gameObject.SetActive(true);
        rt.anchoredPosition = vector;
        rt.gameObject.GetComponent<InventoryButton>().onLeftClick = leftClick;
        rt.gameObject.GetComponent<InventoryButton>().onRightClick = rightClick;
        rt.Find("image").GetComponent<Image>().sprite = image;
    }

    void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
    }

    private void OnEnable()
    {
        inventory.listChanged += AddGraphics;
        AddGraphics();
    }
    private void OnDisable()
    {
        inventory.listChanged -= AddGraphics;
    }
}
