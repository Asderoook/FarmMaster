using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIInvenetory playerUIInvenetory;
    private Inventory playerInventory;

    void Awake()
    {
        playerInventory = GetComponent<Inventory>();
        playerUIInvenetory.inventory = playerInventory;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            playerUIInvenetory.gameObject.SetActive(!playerUIInvenetory.gameObject.activeSelf);
    }
}
