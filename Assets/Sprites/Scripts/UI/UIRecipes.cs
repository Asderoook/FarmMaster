using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRecipes : MonoBehaviour
{
    public Transform itemSlotTemplate;
    public float slotSize;
    public DataBase dataBase;
    public DataCrafts dataCrafts { get; set; }
    private Transform itemSlotContainer;

    public void AddRecipe(Recipe recipe, float y)
    {
        var x = 0.5f;
        foreach (var itemID in recipe.materialsID)
        {
            var item = dataBase.dataBase[itemID];
            RectTransform slotRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            slotRectTransorm.gameObject.SetActive(true);
            slotRectTransorm.anchoredPosition = new Vector2(x * slotSize, y * slotSize);
            slotRectTransorm.localScale = new Vector2(slotSize / 55, slotSize / 55);
            slotRectTransorm.gameObject.GetComponent<InventoryButton>().onLeftClick = () => { };
            slotRectTransorm.gameObject.GetComponent<InventoryButton>().onRightClick = () => { };
            slotRectTransorm.Find("image").GetComponent<Image>().sprite = item.image;
            x++;
        }
        var rectT = gameObject.GetComponent<RectTransform>();
        var resItem = dataBase.dataBase[recipe.resultID];
        RectTransform resSlotRectTransorm = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        resSlotRectTransorm.gameObject.SetActive(true);
        resSlotRectTransorm.anchoredPosition = new Vector2(5 * slotSize, y * slotSize);
        resSlotRectTransorm.localScale = new Vector2(slotSize / 55, slotSize / 55);
        resSlotRectTransorm.gameObject.GetComponent<InventoryButton>().onLeftClick = () => { };
        resSlotRectTransorm.gameObject.GetComponent<InventoryButton>().onRightClick = () => { };
        resSlotRectTransorm.Find("image").GetComponent<Image>().sprite = resItem.image;
        x++;
    }

    private void Awake()
    {
        var scrollView = transform.Find("scrollView");
        var viewport = scrollView.Find("viewport");
        var content = viewport.Find("content");
        itemSlotContainer = content.Find("itemSlotContainer");
    }

    private void OnEnable()
    {
        var y = 0.5f;
        foreach (Transform child in itemSlotContainer)
            Destroy(child.gameObject);
        foreach (var recipe in dataCrafts.dataCrafts)
        {
            AddRecipe(recipe, y--);
        }
    }
}
