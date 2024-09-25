using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float moveSpeed = 0.01f;    // Normal movement speed
    public float sprintMultiplier = 2.0f;  // Multiplier for sprinting
    public float jumpForce = 5.0f;     // Force applied when jumping
    private bool isGrounded = true;    // Check if the player is grounded

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = moveSpeed;

        // Sprint with Shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // Movement controls
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * currentSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.back * currentSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -2);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 2);
        }

        // Jump with Spacebar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Prevent multiple jumps
        }
    }

    // Check if the player is grounded (to allow jumping)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sol"))
        {
            isGrounded = true;
        }
    }
}
