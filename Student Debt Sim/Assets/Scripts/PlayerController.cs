using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalInput, 0.0f, horizontalInput).normalized;

        Vector3 moveDirection = transform.TransformDirection(movement);

        rb.velocity = moveDirection * speed;
    }
}
