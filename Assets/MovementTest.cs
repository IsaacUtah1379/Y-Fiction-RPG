using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTest : MonoBehaviour
{
    public float velocity;
    private InputAction moveAction;
    private Rigidbody2D objectRigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        objectRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue *= velocity * Time.deltaTime;
        Vector2 original = new Vector2(transform.position.x, transform.position.y);
        objectRigidbody.MovePosition(original + moveValue);
    }
}
