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

    mouseInput myInput;
    Vector3 location = Vector3.zero;

    Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        this.pointer = pointer;
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
