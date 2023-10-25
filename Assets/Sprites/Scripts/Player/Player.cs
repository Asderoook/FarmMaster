using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIInvenetory playerUIInvenetory;
    private Inventory playerInventory;
    private bool facingLeft = true;

    void Awake()
    {
        playerInventory = GetComponent<Inventory>();
        playerUIInvenetory.inventory = playerInventory;
    }

    private void Flip()
    {
        facingLeft = !facingLeft;

        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            playerUIInvenetory.gameObject.SetActive(!playerUIInvenetory.gameObject.activeSelf);
        if (Input.GetKeyDown(KeyCode.A) && !facingLeft)
            Flip();
        else if (Input.GetKeyDown(KeyCode.D) && facingLeft)
            Flip();

    }
}
