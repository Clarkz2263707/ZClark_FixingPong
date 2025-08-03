using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerType 
{ 
    Player1,
    Player2 
}

public class Paddle : MonoBehaviour
{
    public PlayerType playerType;
    public float s = 10f;
    public float d = 4f;

    [SerializeField] private InputAction MovementInputs;
    private float Movement;

    void Awake()
    {
        MovementInputs.performed += OnMovePerformed;
        MovementInputs.canceled += OnMoveCanceled;
    }

    void OnEnable()
    {
        MovementInputs.Enable();
    }
    
    void OnDisable()
    {
        MovementInputs.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<float> ();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        Movement = 0;
    }

    void Update()
    {
        float movement = Movement * s * Time.deltaTime;
        transform.Translate(0f, movement, 0f);

        float clampedY = Mathf.Clamp(transform.position.y, -d, d);
        transform.position = new Vector3(transform.position.x, clampedY, 0f);
    }
}
