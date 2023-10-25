using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIGenerator : MonoBehaviour
{
    private Text timer;
    public Sprite buttonImage;
    public GeneratorInventory generatorInventory { get; set; }
    private float slotSize = 55;
    private Transform itemSlotContainer;
    public Transform itemSlotTemplate;
    public Transform itemSlottototo;

    public void AddGraphics()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child != itemSlotTemplate)
                Destroy(child.gameObject);
        }
        RectTransform buttonRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        DrawCell(buttonRectTransorm,
            new Vector2(1 * slotSize, -0.5f * slotSize),
            () => {
                if (generatorInventory.canCraft)
                {
                    generatorInventory.StartGenerating();
                    if (!generatorInventory.canCraft)
                        StartCoroutine(DrawTimer());
                }
            },
            () => {
                if (generatorInventory.canCraft)
                {
                    generatorInventory.StartGenerating();
                    if (!generatorInventory.canCraft)
                        StartCoroutine(DrawTimer());
                }
            },
            buttonImage);
        if (generatorInventory.resultItem != null)
        {
            RectTransform slotRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            DrawCell(slotRectTransorm,
                new Vector2(2 * slotSize, -0.5f * slotSize),
                () => {
                    if (generatorInventory.anotherInventory.canAdd)
                    {
                        generatorInventory.anotherInventory.AddItem(generatorInventory.resultItem);
                        slotRectTransorm.gameObject.SetActive(false);
                        generatorInventory.resultItem = null;
                        generatorInventory.canCraft = true;
                        AddGraphics();
                    }
                },
                () => {
                    if (generatorInventory.anotherInventory.canAdd)
                    {
                        generatorInventory.anotherInventory.AddItem(generatorInventory.resultItem);
                        slotRectTransorm.gameObject.SetActive(false);
                        generatorInventory.resultItem = null;
                        generatorInventory.canCraft = true;
                        AddGraphics();
                    }
                },
                generatorInventory.resultItem.image);
            timer.text = generatorInventory.timer.ToString() + "%";
        }
        else
        {
            var rt = Instantiate(itemSlottototo, itemSlotContainer).GetComponent<RectTransform>();
            rt.gameObject.SetActive(true);
            rt.anchoredPosition = new Vector2(2 * slotSize, -0.5f * slotSize);
            rt.Find("Image").GetComponent<Image>().sprite = generatorInventory.GetItem().image;
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
        while (generatorInventory.resultItem == null)
        {
            timer.text = generatorInventory.timer.ToString() + "%";
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
        generatorInventory.resultItemChanged += AddGraphics;
        if (!generatorInventory.canCraft)
            StartCoroutine(DrawTimer());
        AddGraphics();
    }
    private void OnDisable()
    {
        generatorInventory.resultItemChanged -= AddGraphics;
    }
}
