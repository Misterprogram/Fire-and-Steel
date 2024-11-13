using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrole : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    private bool isGround;
    private CapsuleCollider playerCollider;
    private float originalColliderHeight;
    private Vector3 originalColliderCenter;
    public float runSpeed = 10f;
    private float currentSpeed;
    private Renderer playerRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerRenderer = GetComponentInChildren<Renderer>();
        playerRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        originalColliderHeight = playerCollider.height;
        originalColliderCenter = playerCollider.center;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * currentSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (Input.GetKey(KeyCode.LeftShift) && !(Input.GetKey(KeyCode.LeftControl)))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.Space) && isGround )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);

            playerCollider.height = originalColliderHeight / 2;
            playerCollider.center = originalColliderCenter / 2;

        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            playerCollider.height = originalColliderHeight;
            playerCollider.center = originalColliderCenter;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
