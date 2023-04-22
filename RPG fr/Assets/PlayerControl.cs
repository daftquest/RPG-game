using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController controller;
    Vector2 playerInp;

    float playerSpeed = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInp.x = Input.GetAxisRaw("Horizontal");
        playerInp.y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(playerInp.x, 0f, playerInp.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * playerSpeed * Time.deltaTime);
        }
    }
}
