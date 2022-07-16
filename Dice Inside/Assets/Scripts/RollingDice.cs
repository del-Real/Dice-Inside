using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour {

    [SerializeField] float rollSpeed = 3;
    private bool isRolling;

    void Start() {

    }

    void Update() {
        if (isRolling) return;

        var anchor = transform.position + new Vector3(0f, -2.5f, -2.5f);
        var axis = Vector3.Cross(Vector3.up, -Vector3.forward);
        StartCoroutine(Roll(anchor, axis));
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        isRolling = true;

        for (int i = 0; i < (90 / rollSpeed); i++) {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isRolling = false;
    }
}
