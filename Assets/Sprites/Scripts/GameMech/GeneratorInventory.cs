using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInventory : MonoBehaviour
{
    public Item resultItem { get; set; }
    public int generatingItemID;
    public float generatingTime;
    public float timer { get; set; }
    public bool canCraft;
    public DataBase dataBase;
    public event Action resultItemChanged;
    public Inventory anotherInventory { get; set; }

    public Item GetItem()
    {
        return dataBase.dataBase[generatingItemID];
    }

    private IEnumerator StartTimer()
    {
        var time = generatingTime;
        var currentTime = 0f;
        while (currentTime <= time)
        {
            timer = Mathf.Round(currentTime / time * 100);
            yield return null;
            currentTime += Time.deltaTime;
        }
        timer = 100;
        resultItem = dataBase.dataBase[generatingItemID];
        resultItemChanged?.Invoke();
    }

    public void EndGenerating()
    {
        StopAllCoroutines();
    }

    public void StartGenerating()
    {
        canCraft = false;
        StartCoroutine(StartTimer());
    }

    private void Start()
    {
        resultItem = null;
        canCraft = true;
    }
}
