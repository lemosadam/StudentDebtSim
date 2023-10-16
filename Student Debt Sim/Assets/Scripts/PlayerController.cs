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

        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Manually swap input directions
        float newVerticalInput = horizontalInput;
        float newHorizontalInput = -verticalInput;

        // Calculate the movement vector
        Vector3 movement = new Vector3(newHorizontalInput, 0.0f, newVerticalInput).normalized;

        // Apply the movement directly to the Rigidbody
        rb.velocity = movement * speed;

        // Handle scaling growth
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

    public void DoubleSpeed()
    {
        speed *= 2.0f;
    }

    public void HalveSpeed()
    {
        speed *= 0.5f;
    }

    public void DoubleCoinShrinkFactor()
    {
        currentScale *= 2.0f;
        ApplyScale();
    }

    public void HalveCoinShrinkFactor()
    {
        currentScale *= 0.5f;
        ApplyScale();
    }
}


