using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInventory : MonoBehaviour
{
    public int[] dishes { get; set; }
    private DataBase dataBase;
    private Inventory inventory;
    private GameStart gameStart;

    public List<Item> GetItems()
    {
        var result = new List<Item>();
        foreach (var itemID in dishes)
            result.Add(dataBase.dataBase[itemID]);
        return result;
    }

    public void CheckWin()
    {
        var items = inventory.items;
        var result = new int[items.Count];
        for (var i = 0; i < items.Count; i++)
            result[i] = items[i].id;
        System.Array.Sort(result);
        if (ArrayEqual(dishes, result))
            gameStart.GameWon();
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
        inventory = GetComponent<Inventory>();
        gameStart = GetComponent<GameStart>();
        dataBase = inventory.data;
    }
}
