using UnityEngine;

public class InteractionWorkbench : MonoBehaviour
{
    public UIWorkbench workbenchUIInventory;
    public Inventory workbenchInventory;
    public WbInventory wbInventory;
    public DataCrafts dataCrafts;
    private Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInventory = collision.gameObject.GetComponent<Inventory>();
        workbenchUIInventory.inventory = workbenchInventory;
        workbenchUIInventory.wbInventory = wbInventory;
        workbenchUIInventory.gameObject.SetActive(true);
        playerInventory.anotherInventory = workbenchInventory;
        workbenchInventory.anotherInventory = playerInventory;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        workbenchUIInventory.gameObject.SetActive(false);
        playerInventory.anotherInventory = null;
        workbenchInventory.anotherInventory = null;
    }
}
