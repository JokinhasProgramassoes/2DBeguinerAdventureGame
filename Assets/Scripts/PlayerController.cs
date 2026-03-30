using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //public InputAction LeftAction;
    public InputAction MoveAction;

    void Start()
    {
        //LeftAction.Enable();
        MoveAction.Enable();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;
    }

    void Update()
    {
        //Mover o personagem
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + move * 3.0f *  Time.deltaTime;
        transform.position = position;

    
        //Input horizontal:
       /* float horizontal = 0.0f;
        if (LeftAction.IsPressed())
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }

        //Input Vertical
        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
        }
*/
        
        //position.x = position.x + 0.1f * horizontal;
        //position.y = position.y + 0.1f * vertical;
    }
}
