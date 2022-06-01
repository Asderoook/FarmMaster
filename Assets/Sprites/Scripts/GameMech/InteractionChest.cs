using UnityEngine;

public class InteractionChest : MonoBehaviour
{
    public UIInvenetory chestUIInventory;
    public Inventory chestInventory;
    private Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInventory = collision.gameObject.GetComponent<Inventory>();
        chestUIInventory.inventory = chestInventory;
        chestUIInventory.gameObject.SetActive(true);
        playerInventory.anotherInventory = chestInventory;
        chestInventory.anotherInventory = playerInventory;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        chestUIInventory.gameObject.SetActive(false);
        playerInventory.anotherInventory = null;
        chestInventory.anotherInventory = null;
    }
}
