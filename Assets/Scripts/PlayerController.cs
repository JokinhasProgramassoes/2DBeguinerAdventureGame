using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //public InputAction LeftAction;
    public InputAction MoveAction;
    Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        //LeftAction.Enable();
        MoveAction.Enable();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //Mover o personagem
        move = MoveAction.ReadValue<Vector2>();
        
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + move * 3.0f *  Time.deltaTime;
        rb.position = position;
    }
}
