using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class PlayerController : MonoBehaviour
{
    public InputAction talkAction;

    public GameObject projectilePrefab;
    public InputAction MoveAction;
    Rigidbody2D rb;
    Vector2 move;
    public float speed = 3.0f;

    //Cooldown de dano recibdio
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;
    
    //Health sistem:
    public int maxHealth = 5;
    public int health {get { return currentHealth;}}
    int currentHealth;

    //Animacao:
    Animator animator;
    Vector2 moveDirection = new Vector2(1,0);

    
    void Start()
    {
        //LeftAction.Enable();
        MoveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();

        talkAction.Enable();
    }

    void Update()
    {
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        //Mover o personagem
        move = MoveAction.ReadValue<Vector2>();

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }
        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            FindFriend();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + move * speed *  Time.deltaTime;
        rb.position = position;
    }

    public void ChangeHealth (int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;

            animator.SetTrigger("Hit");
        }
        currentHealth = Math.Clamp(currentHealth + amount, 0, maxHealth);
        UiHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);
        Projetil projectile = projectileObject.GetComponent<Projetil>();
        projectile.Launch(moveDirection, 300);
        animator.SetTrigger("Launch");
    }

    void FindFriend()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NPCscript character = hit.collider.GetComponent<NPCscript>();
            if (character != null)
            {
                UiHandler.instance.DisplayDialogue();
            }
        }
    }
}
