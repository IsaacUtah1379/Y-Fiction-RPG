using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PartyMovement : MonoBehaviour
{
    public int moveListLength;
    private List<Vector2> movements;
    private InputAction moveAction;
    private GameObject first;
    private GameObject second;
    private GameObject third;
    private GameObject fourth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < moveListLength; i++) {
            movements.Add(Vector2.zero);
        }

        moveAction = InputSystem.actions.FindAction("move");

        first = transform.Find("First").gameObject;
        second = transform.Find("Second").gameObject;
        third = transform.Find("Third").gameObject;
        fourth = transform.Find("Fourth").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMove = moveAction.ReadValue<Vector2>();
        if (currentMove != Vector2.zero) {
            movements.RemoveAt(0);
            movements.Add(currentMove);

            
        }
    }
}
