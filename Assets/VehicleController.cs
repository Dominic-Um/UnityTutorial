using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    public CheckpointController target;
    private Vector2 movementInput = Vector2.zero;
    public float forceMultiplier = 15f;
    public float turnRate = 75f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
    }

    void OnMove(InputValue action)
    {
        movementInput = action.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 force = new Vector3(movementInput.x, 0, movementInput.y) * forceMultiplier;
        rb.AddRelativeForce(force, ForceMode.Acceleration);
    }

    void Update()
    {
        float dx = (Mouse.current.position.x.value - Screen.width / 2f) / 200f;
        dx = Mathf.Clamp(dx, -1f, 1f);
        if (Mathf.Abs(dx) > 0.01f)
        {
            float turn = dx * turnRate * Time.deltaTime;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turn, 0));
        }
    }
}