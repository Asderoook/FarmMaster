using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMove : MonoBehaviour
{
    public float Speed;
    private Vector2 vector;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + vector.normalized * Speed * Time.fixedDeltaTime);
    }
}
