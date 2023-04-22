using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController controller;
    Vector2 playerInp;

    Vector3 velocity;
    float gravity = -20f;
    public Transform groundChecker;
    float groundCheckR = 0.3125f;
    public LayerMask groundLayer;
    bool isGrounded = true;

    float playerSpeed = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckR, groundLayer);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        velocity.y += gravity * Time.deltaTime;

        playerInp.x = Input.GetAxisRaw("Horizontal");
        playerInp.y = Input.GetAxisRaw("Vertical");

        controller.Move(velocity * Time.deltaTime);

        Vector3 direction = new Vector3(playerInp.x, 0f, playerInp.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * playerSpeed * Time.deltaTime);
        }
    }
}
