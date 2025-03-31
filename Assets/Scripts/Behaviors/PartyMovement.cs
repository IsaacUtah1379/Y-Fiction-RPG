using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PartyMovement : MonoBehaviour
{
    public int moveListLength;
    public float velocity;
    private List<Vector2> locations = new List<Vector2>();
    private InputAction moveAction;
    private GameObject first;
    private GameObject second;
    private GameObject third;
    private GameObject fourth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < moveListLength; i++) {
            locations.Add(Vector2.zero);
        }

        moveAction = InputSystem.actions.FindAction("Move");

        first = transform.Find("First").gameObject;
        second = transform.Find("Second").gameObject;
        third = transform.Find("Third").gameObject;
        fourth = transform.Find("Fourth").gameObject;
    }

    void FixedUpdate()
    {
        Vector2 currentMove = moveAction.ReadValue<Vector2>();
        if (currentMove != Vector2.zero) {
            first.transform.Translate(Time.fixedDeltaTime * velocity * currentMove);

            locations.RemoveAt(0);
            locations.Add(first.transform.position);

            second.transform.position = locations[^((locations.Count / 3) + 1)];
            third.transform.position = locations[locations.Count / 3];
            fourth.transform.position = locations[0];
        }
    }
}
