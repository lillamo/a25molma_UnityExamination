using UnityEngine;
using UnityEngine.InputSystem;

            /////////////// INFORMATION ///////////////
// This script automatically adds a Rigidbody2D and a CapsuleCollider2D component in the inspector.
// The following components are needed: Player Input

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class TopDownMovement : MonoBehaviour
{
    public float maxSpeed = 7;
    
    public bool controlEnabled { get; set; } = true;    // You can edit this variable from Unity Events
    
    private Vector2 moveInput;
    private Rigidbody2D rb;
    
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        anim = GetComponentInChildren<Animator>(); // <— FIX
    }


    private void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        Vector2 velocity = controlEnabled 
            ? moveInput.normalized * maxSpeed 
            : Vector2.zero;

        rb.linearVelocity = velocity;

      

        anim.SetFloat("MoveX", velocity.x);
        anim.SetFloat("MoveY", velocity.y);
        anim.SetFloat("Speed", velocity.sqrMagnitude);
    }
    
    // Handle Move-input
    // This method can be triggered through the UnityEvent in PlayerInput
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().normalized;
        
    }
}
