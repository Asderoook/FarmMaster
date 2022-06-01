using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public UIManager managerUI;
    public Inventory workbenchInventory;
    public ManagerInventory managerInventory;
    private Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInventory = collision.gameObject.GetComponent<Inventory>();
        managerUI.inventory = workbenchInventory;
        managerUI.managerInventory = managerInventory;
        managerUI.gameObject.SetActive(true);
        playerInventory.anotherInventory = workbenchInventory;
        workbenchInventory.anotherInventory = playerInventory;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        managerUI.gameObject.SetActive(false);
        playerInventory.anotherInventory = null;
        workbenchInventory.anotherInventory = null;
    }
}
