using System;
using System.Collections;
using UnityEngine;

public class WbInventory : MonoBehaviour
{
    public Item resultItem { get; set; }
    public float timer;
    public bool canCraft;
    private DataBase dataBase;
    public event Action itemChanged;
    private CraftSystem craftSystem;

    private IEnumerator StartTimer(Recipe recipe)
    {
        var time = recipe.craftingTime;
        var currentTime = 0f;
        while (currentTime <= time)
        {
            timer = Mathf.Round(currentTime / time * 100);
            yield return null;
            currentTime += Time.deltaTime;
        }
        timer = 100;
        resultItem = dataBase.dataBase[recipe.resultID];
        itemChanged?.Invoke();
    }

    public Item FindResultItem()
    {
        var result = craftSystem.GetRecipe();
        if (result != null)
            return dataBase.dataBase[result.resultID];
        return null;
    }

    public void EndCrafting()
    {
        StopAllCoroutines();
    }

    public void StartCrafting()
    {
        var recipe = craftSystem.Craft();
        if (recipe != null)
        {
            canCraft = false;
            StartCoroutine(StartTimer(recipe));
        }
    }

    private void Awake()
    {
        craftSystem = GetComponent<CraftSystem>();
    }

    private void Start()
    {
        dataBase = craftSystem.dataBase;
        resultItem = null;
        canCraft = true;
    }
}
