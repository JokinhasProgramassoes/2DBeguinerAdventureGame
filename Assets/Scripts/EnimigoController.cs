using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnimigoController : MonoBehaviour
{
    //Movement
    public bool vertical; 
    public float speed;

    //Patrol 
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    { 
        Vector2 position = rb.position;
        
        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
        }

        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
        }
       
        rb.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
