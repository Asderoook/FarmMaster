using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIWorkbench : MonoBehaviour
{
    private Text timer;
    public Sprite buttonImage;
    public Inventory inventory { get; set; }
    public WbInventory wbInventory { get; set; }
    private float slotSize = 55;
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
        var y = 0;
        foreach (Item item in inventory.GetItems())
        {
            RectTransform slotRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            DrawCell(slotRectTransorm,
                new Vector2(x * slotSize, y * slotSize),
                () => inventory.GiveItem(item),
                () => inventory.RemoveItem(item),
                item.image);
            if (++x >= inventory.maxCount / 2 + inventory.maxCount % 2)
            {
                x = 0;
                y--;
            }
        }
        RectTransform buttonRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        DrawCell(buttonRectTransorm,
            new Vector2(2 * slotSize, -0.5f * slotSize),
            () => {
                if (wbInventory.canCraft)
                {
                    wbInventory.StartCrafting();
                    if (!wbInventory.canCraft)
                        StartCoroutine(DrawTimer());
                }
            },
            () => {
                wbInventory.EndCrafting();
                StopAllCoroutines();
                wbInventory.canCraft = true;
            },
            buttonImage);
        if (wbInventory.resultItem != null)
        {
            RectTransform slotRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            DrawCell(slotRectTransorm,
                new Vector2(3 * slotSize, -0.5f * slotSize),
                () => {
                    inventory.anotherInventory.AddItem(wbInventory.resultItem);
                    slotRectTransorm.gameObject.SetActive(false);
                    wbInventory.resultItem = null;
                    wbInventory.canCraft = true;
                },
                () => {
                    slotRectTransorm.gameObject.SetActive(false);
                    wbInventory.resultItem = null;
                    wbInventory.canCraft = true;
                },
                wbInventory.resultItem.image);
            timer.text = wbInventory.timer.ToString() + "%";
        }
    }

    public void DrawCell(RectTransform rt, Vector2 vector, Action leftClick, Action rightClick, Sprite image)
    {
        rt.gameObject.SetActive(true);
        rt.anchoredPosition = vector;
        rt.gameObject.GetComponent<InventoryButton>().onLeftClick = leftClick;
        rt.gameObject.GetComponent<InventoryButton>().onRightClick = rightClick;
        rt.Find("image").GetComponent<Image>().sprite = image;
    }

    public IEnumerator DrawTimer()
    {
        while (wbInventory.resultItem == null)
        {
            timer.text = wbInventory.timer.ToString() + "%";
            yield return null;
        }
    }

    void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        timer = transform.Find("timer").gameObject.GetComponent<Text>();
    }

    private void OnEnable()
    {
        inventory.listChanged += AddGraphics;
        wbInventory.itemChanged += AddGraphics;
        if (!wbInventory.canCraft)
            StartCoroutine(DrawTimer());
        AddGraphics();
    }
    private void OnDisable()
    {
        inventory.listChanged -= AddGraphics;
        wbInventory.itemChanged -= AddGraphics;
    }
}
