using UnityEngine;

public class GameStart : MonoBehaviour
{
    public DataStarts dataStarts;
    public ChestFilling chestFilling;
    private ManagerInventory managerInventory;
    private StartDish startDish;

    private void Start()
    {
        var rnd = new System.Random();
        startDish = dataStarts.startDishes[rnd.Next(0, dataStarts.startDishes.Count - 1)];
        chestFilling.Filling(startDish.chessFillingItemsID);
        managerInventory.dishes = startDish.dishIDs;
    }

    private void Awake()
    {
        managerInventory = GetComponent<ManagerInventory>();
    }
}
