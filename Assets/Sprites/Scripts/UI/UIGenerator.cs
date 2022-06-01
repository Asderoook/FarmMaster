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

    public void AddGraphics()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child != itemSlotTemplate)
                Destroy(child.gameObject);
        }
        RectTransform TemplateRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        DrawCell(TemplateRectTransorm,
            new Vector2(0, -0.5f * slotSize),
            () => { },
            () => { },
            generatorInventory.GetItem().image);
        RectTransform buttonRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        DrawCell(buttonRectTransorm,
            new Vector2(2 * slotSize, -0.5f * slotSize),
            () => {
                if (generatorInventory.canCraft)
                {
                    generatorInventory.StartGenerating();
                    if (!generatorInventory.canCraft)
                        StartCoroutine(DrawTimer());
                }
            },
            () => {
                generatorInventory.EndGenerating();
                StopAllCoroutines();
                generatorInventory.canCraft = true;
            },
            buttonImage);
        if (generatorInventory.resultItem != null)
        {
            RectTransform slotRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            DrawCell(slotRectTransorm,
                new Vector2(3 * slotSize, -0.5f * slotSize),
                () => {
                    generatorInventory.anotherInventory.AddItem(generatorInventory.resultItem);
                    slotRectTransorm.gameObject.SetActive(false);
                    generatorInventory.resultItem = null;
                    generatorInventory.canCraft = true;
                },
                () => {
                    slotRectTransorm.gameObject.SetActive(false);
                    generatorInventory.resultItem = null;
                    generatorInventory.canCraft = true;
                },
                generatorInventory.resultItem.image);
            timer.text = generatorInventory.timer.ToString() + "%";
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
