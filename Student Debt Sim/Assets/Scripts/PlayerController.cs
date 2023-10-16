using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;

    public float growthRate = 0.05f;
    public float originalScale = 1.0f;
    public float minScale = 0.5f;
    public float maxScale = 10.0f;

    public GameObject gameOver;

    private float turnSpeed = 90f;
    private float currentScale;
    private float timeSinceLastScaleChange;

    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentScale = originalScale;
        timeSinceLastScaleChange = Time.time;
        ApplyScale();
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
    }

    void Update()
    {


        float horizontalInput = Input.GetAxis("Horizontal");

        // Check for A key press to rotate the player sphere to the left
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -90.0f);
        }
        
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 90.0f);
        }

        float verticalInput = -Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(verticalInput, 0.0f, 0.0f).normalized;

        Vector3 moveDirection = transform.TransformDirection(movement);

        rb.velocity = moveDirection * speed;

        if (Time.time - timeSinceLastScaleChange >= 1.0f)
        {
            Grow();
            timeSinceLastScaleChange = Time.time;
        }

        if (currentScale >= 2.5f)
        {
            gameOver.SetActive(true);
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


