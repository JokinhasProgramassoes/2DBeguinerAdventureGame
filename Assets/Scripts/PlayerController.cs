using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        //Mover o personagem
        Vector2 position = transform.position;
        position.x = position.x + 0.1f;
        transform.position = position;
        
    }
}
