using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerControl : MonoBehaviour
{
    CharacterController controller;
    Vector2 playerInp;

    Vector3 velocity;
    float gravity = -20f;
    public Transform groundChecker;
    float groundCheckR = 0.3125f;
    public LayerMask groundLayer;
    bool isGrounded = true;

    bool isNearTown;
    public LayerMask townLayer;

    float playerSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isNearTown = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Bool that recognizes when the player is on the ground
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckR, groundLayer);
        
        // If player is on ground and is falling, set the velocity to be slower by default.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -4f;
        }

        // Adding gravity
        velocity.y += gravity * Time.deltaTime;

        // Getting the player's input for the player's movement on the map
        playerInp.x = Input.GetAxisRaw("Horizontal");
        playerInp.y = Input.GetAxisRaw("Vertical");

        // Applying gravity to the MC
        controller.Move(velocity * Time.deltaTime);

        // Setting a new Vector 3 to wherever the player is pressing buttons
        Vector3 direction = new Vector3(playerInp.x, 0f, playerInp.y).normalized;

        // If the player's input exists, they move.
        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * playerSpeed * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == townLayer)
        {
            isNearTown = true;
            Debug.Log("Near Town!");
        }
    }
}
