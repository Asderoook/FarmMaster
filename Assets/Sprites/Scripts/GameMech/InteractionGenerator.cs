using UnityEngine;

public class InteractionGenerator : MonoBehaviour
{
    public UIGenerator generatorUI;
    public GeneratorInventory generatorInventory;
    private Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInventory = collision.gameObject.GetComponent<Inventory>();
        generatorUI.generatorInventory = generatorInventory;
        generatorUI.gameObject.SetActive(true);
        generatorInventory.anotherInventory = playerInventory;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        generatorUI.gameObject.SetActive(false);
        playerInventory.anotherInventory = null;
    }
}
