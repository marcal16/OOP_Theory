using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerControllerBase : MonoBehaviour
{
    
    [SerializeField] protected float speed = 5f;
    public bool isActive;
    protected Vector2 moveInput;

    protected Rigidbody playerRb;
    protected InputSystem_Actions controls;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        controls = new InputSystem_Actions();
    }

    protected virtual void OnEnable()
    {
        controls.Enable();
        controls.Player.Move.performed += Move;
        controls.Player.Move.canceled += Move;
        controls.Player.Interact.performed += ChangeState;
    }

    protected virtual void OnDisable ()
    {
        controls.Player.Interact.performed -= ChangeState;
        controls.Player.Move.canceled -= Move;
        controls.Player.Move.performed -= Move;
        controls.Disable();
    }

    protected virtual void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    protected virtual void FixedUpdate()
    {
        if (!isActive)
        {
            return;
        }
        playerRb.linearVelocity = new Vector3(moveInput.x, 0f, moveInput.y) * speed;
    }

    protected abstract void ChangeState(InputAction.CallbackContext context);
    public abstract void EnableControl();
    public abstract void DisableControl();

}
