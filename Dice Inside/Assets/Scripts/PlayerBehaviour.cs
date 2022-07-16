using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    private float vInput;
    private float hInput;

    // Update is called once per frame
    void Update() {

        PlayerMovement();
    }

    void PlayerMovement() {

        vInput = Input.GetAxisRaw("Vertical");
        hInput = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(hInput, 0.0f, vInput);

        /*
        // FIX: Look Rotation Viewing Vector Is Zero
        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);
        }
        */

        transform.Translate(movement.normalized * moveSpeed * Time.deltaTime);

    }

}
