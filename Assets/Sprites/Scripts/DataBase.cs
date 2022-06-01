using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Database", menuName = "Assets/Databases/Item Database")]
public class DataBase : ScriptableObject
{
    public List<Item> dataBase = new();
}

[System.Serializable]
public class Item
{
    public int id;
    public string itemName;
    public Sprite image;
}