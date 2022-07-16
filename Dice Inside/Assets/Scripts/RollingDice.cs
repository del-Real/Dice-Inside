using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour {

    [SerializeField] float rollSpeed;
    private bool isRolling;

    void Start() {

    }

    void Update() {
        if (isRolling) return;

        var anchor = transform.position + new Vector3(0f, -5f, -5f);
        var axis = Vector3.Cross(Vector3.up, -Vector3.forward);
        Roll(anchor, axis);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Game Over!!!");
        }
    }

    // IEnumerator Roll(Vector3 anchor, Vector3 axis) {
    //     isRolling = true;

    //     for (int i = 0; i < (90 / rollSpeed); i++) {
    //         transform.RotateAround(anchor, axis, rollSpeed);
    //         yield return new WaitForSeconds(0.01f);
    //     }

    //     isRolling = false;
    // }

    void Roll(Vector3 anchor, Vector3 axis) {
        isRolling = true;

        for (int i = 0; i < (90 / rollSpeed * Time.deltaTime); i++) {
            transform.RotateAround(anchor, axis, rollSpeed);
        }

        isRolling = false;
    }
}
