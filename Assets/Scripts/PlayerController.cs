using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class PlayerController : MonoBehaviour
{
    //public InputAction LeftAction;
    public InputAction MoveAction;
    Rigidbody2D rb;
    Vector2 move;
    public float speed = 3.0f;
    
    //Health sistem:
    public int maxHealth = 5;
    int currentHealth = 1;
    
    void Start()
    {
        //LeftAction.Enable();
        MoveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        //currentHealth = maxHealth;
    }

    void Update()
    {
        //Mover o personagem
        move = MoveAction.ReadValue<Vector2>();
        
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + move * speed *  Time.deltaTime;
        rb.position = position;
    }

    public void ChangeHealth (int amount)
    {
        currentHealth = Math.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
