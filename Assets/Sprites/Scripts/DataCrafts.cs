using System.Collections.Generic;
using UnityEngine;

public class DataCrafts : MonoBehaviour
{
    [SerializeField]
    public List<Recipe> dataCrafts;
}

[System.Serializable]
public class Recipe
{
    public int[] materialsID;
    public int resultID;
    public float craftingTime;
}