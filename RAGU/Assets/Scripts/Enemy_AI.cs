using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public Vector2 speed = new Vector2(20, 50);
    // 2 - направление движения 
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
    }
    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
