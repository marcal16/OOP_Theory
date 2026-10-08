using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerControllerBase
{

    [SerializeField] private float sprintVelocity = 5f;
    private float speedModifier = 1f;
    [SerializeField] private float jumpForce = 10f;
    public LayerMask layerMask;

    protected override void OnEnable()
    {
        base.OnEnable();
        controls.Player.Jump.performed += jump;
        controls.Player.Sprint.performed += sprint;
        controls.Player.Sprint.canceled += sprint;

    }

    protected override void OnDisable()
    {
        controls.Player.Jump.performed -= jump;
        controls.Player.Sprint.performed -= sprint;
        controls.Player.Sprint.canceled -= sprint;
        base.OnDisable();
    }

    protected override void FixedUpdate()
    {
        if (!isActive)
        {
            return;
        }
        playerRb.linearVelocity = new Vector3(moveInput.x, 0f, moveInput.y) * speed * speedModifier;
    }

    private void jump(InputAction.CallbackContext context)
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void sprint(InputAction.CallbackContext context)
    {
        float triggerValue = context.ReadValue<float>();
        speedModifier = Mathf.Pow(sprintVelocity, triggerValue);
    }

    protected override void ChangeState(InputAction.CallbackContext context)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f, layerMask);
        
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.name + " is within range!");
        }
    }

    public override void EnableControl()
    {
        
    }

    public override void DisableControl()
    {
        
    }

}
