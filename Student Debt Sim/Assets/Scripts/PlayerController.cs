using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;

    public float growthRate = 0.1f;  
    public float originalScale = 1.0f;  
    public float minScale = 0.5f;
    public float maxScale = 10.0f;

    private float rotationSpeed = 10f;
    private float currentScale;
    private float timeSinceLastScaleChange;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentScale = originalScale;
        timeSinceLastScaleChange = Time.time;
        ApplyScale();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalInput, 0.0f, horizontalInput).normalized;

        Vector3 moveDirection = transform.TransformDirection(movement);

        rb.velocity = moveDirection * speed;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (Time.time - timeSinceLastScaleChange >= 1.0f)
        {
            Grow();
            timeSinceLastScaleChange = Time.time;
        }

    }
   
    void Grow()
    {
        currentScale += growthRate;
        ApplyScale();
    }

    public void Shrink(float amount)
    {
        currentScale -= amount;
        ApplyScale();
    }

    void ApplyScale()
    {
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

 
}

