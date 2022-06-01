using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dishes Database", menuName = "Assets/Databases/Dishes Database")]
public class DataStarts : ScriptableObject
{
    public List<StartDish> startDishes;
}

[System.Serializable]
public class StartDish
{
    public int[] dishIDs;
    public List<int> chessFillingItemsID;
}
