using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private float speed = 4f;
    public Transform playerTransform;
    public Vector2 playerInp;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInp.y = Input.GetAxisRaw("Vertical");
        playerInp.x = Input.GetAxisRaw("Horizontal");

        playerTransform.Translate(Vector3.up * playerInp.y * speed * Time.deltaTime);
        playerTransform.Translate(Vector3.right * playerInp.x * speed * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        
    }
}
