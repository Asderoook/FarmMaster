using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    public DataBase dataBase;
    private DataCrafts dataCrafts;
    private Inventory inventory;

    public Recipe GetRecipe()
    {
        var items = inventory.items;
        if (items.Count == 0)
            return null;
        var materials = new int[items.Count];
        for (var i = 0; i < items.Count; i++)
            materials[i] = items[i].id;
        System.Array.Sort(materials);
        foreach (var recipe in dataCrafts.dataCrafts)
            if (ArrayEqual(recipe.materialsID, materials))
            {
                return recipe;
            }
        return null;
    }

    public Recipe Craft()
    {
        var items = inventory.items;
        if (items.Count == 0)
            return null;
        var materials = new int[items.Count];
        for (var i = 0; i < items.Count; i++)
            materials[i] = items[i].id;
        System.Array.Sort(materials);
        foreach (var recipe in dataCrafts.dataCrafts)
            if (ArrayEqual(recipe.materialsID, materials))
            {
                inventory.Clear();
                return recipe;
            }
        return null;
    }

    bool ArrayEqual(int[] first, int[] second)
    {
        if (first.Length == second.Length)
        {
            for (var i = 0; i < first.Length; i++)
                if (first[i] != second[i])
                    return false;
            return true;
        }
        return false;
    }

    void Awake()
    {
        dataCrafts = gameObject.GetComponent<DataCrafts>();
        inventory = gameObject.GetComponent<Inventory>();
        dataBase = inventory.data;
    }

}
