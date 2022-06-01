using UnityEngine;
using UnityEngine.UI;

public class UIInvenetory : MonoBehaviour
{
    private float slotSize = 55;
    public Inventory inventory { get; set; }
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
            slotRectTransorm.gameObject.SetActive(true);
            slotRectTransorm.anchoredPosition = new Vector2(x * slotSize, y * slotSize);
            slotRectTransorm.gameObject.GetComponent<InventoryButton>().onLeftClick = () => inventory.GiveItem(item);
            slotRectTransorm.gameObject.GetComponent<InventoryButton>().onRightClick = () => inventory.RemoveItem(item);
            slotRectTransorm.Find("image").GetComponent<Image>().sprite = item.image;
            x++;
            if (x >= inventory.maxCount / 2 + inventory.maxCount % 2)
            {
                x = 0;
                y--;
            }
        }
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
