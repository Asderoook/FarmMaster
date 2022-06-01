using System.Collections.Generic;
using UnityEngine;

public class ChestFilling : MonoBehaviour
{
    public DataBase dataBase;
    private Transform parentTransform;

    public void Filling(List<int> items)
    {
        var placesCount = 0;
        foreach (Transform child in parentTransform)
            placesCount += child.gameObject.GetComponent<Inventory>().maxCount;
        var itemsArray = new Item[placesCount];
        for (var i = 0; i < items.Count; i++)
            itemsArray[i] = dataBase.dataBase[items[i]];
        Shuffle(itemsArray);
        var currentPlace = 0;
        foreach (Transform child in parentTransform)
        {
            var inventory = child.gameObject.GetComponent<Inventory>();
            var max = currentPlace + inventory.maxCount;
            for (; currentPlace < max; currentPlace++)
                if (itemsArray[currentPlace] != null)
                    inventory.items.Add(itemsArray[currentPlace]);
        }
    }

    public static void Shuffle(object[] array)
    {
        if (array.Length > 0)
        {
            var random = new System.Random();
            for (var i = 0; i < array.Length; i++)
            {
                var obj = array[i];
                var rnd = random.Next(i, array.Length);
                array[i] = array[rnd];
                array[rnd] = obj;
            }
        }
        
    }

    void Awake()
    {
        parentTransform = GetComponent<Transform>();
    }
}
