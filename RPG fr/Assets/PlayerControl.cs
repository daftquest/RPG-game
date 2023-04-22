using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float speed = 6f;
    float gravity = -15f;
    Vector3 velocity;
    Vector2 pInput;
    CharacterController controller;
    public Transform cam;
    float turnSmoothVelocity;
    public Transform groundChecker;
    float groundCheckDist = 0.025f;
    public LayerMask groundLayer;
    bool isGrounded = true;
    float turnSmoothTime = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckDist, groundLayer);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        pInput.x = Input.GetAxisRaw("Horizontal");
        pInput.y = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(pInput.x, 0f, pInput.y).normalized;

        velocity.y += (gravity * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
