using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour {

    [SerializeField] float rollSpeed;
    private bool isRolling;
    private MeshCollider meshCollider;

    void Start() {
        meshCollider = GetComponent<MeshCollider>();
    }

    void Update() {
        if (isRolling) return;

        var anchor = transform.position + new Vector3(0f, -5f, -5f);
        var axis = Vector3.Cross(Vector3.up, -Vector3.forward);
        StartCoroutine(Roll(anchor, axis));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(meshCollider);
            Debug.Log("Collider Destroyed!!!");
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Game Over!!!");
        }
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
