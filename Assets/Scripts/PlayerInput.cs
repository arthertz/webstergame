using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct mouseInput
{
    public float x;
    public float y;
}

public class PlayerInput : MonoBehaviour
{
    public float speed = 5f;
    private GameObject pointer;
    private bool initialized = false;

    mouseInput myInput;
    Vector3 location;

    Vector2 movementInput;


    // Update is called once per frame
    void Update()
    {
        if (!initialized) return;
        Debug.Log("Initialized");
        if (!pointer) return;
        Debug.Log("Pointer exists");

        location.x = myInput.x;
        location.z = myInput.y;

        pointer.transform.position = location;

        myInput.x += movementInput.x * Time.deltaTime * speed;
        //Debug.Log(horizontalInputName + " input.x " + myInput.x);
        myInput.y += movementInput.y * Time.deltaTime * speed;
        //Debug.Log(verticalInputName + " input.y " + myInput.y);

    }

    public void SetPointer(GameObject pointer)
    {
        this.location = transform.position;
        myInput.x = location.x;
        myInput.y = location.z;
        this.pointer = pointer;
        initialized = true;
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
