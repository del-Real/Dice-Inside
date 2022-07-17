using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour {

    private float rollSpeed = 0.5f;
    private bool isRolling;
    private MeshCollider meshCollider;
    private GameManager gameManager;

    void Start() {
        meshCollider = GetComponent<MeshCollider>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update() {
        if (isRolling) return;
        if (transform.position.z < -70) Destroy(gameObject);

        var anchor = transform.position + new Vector3(0f, -10f, -10f);
        var axis = Vector3.Cross(Vector3.up, -Vector3.forward);
        StartCoroutine(Roll(anchor, axis));
    }

    public void IncreaseRandomSpeed() {
        rollSpeed += Random.Range(0.01f, 0.03f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(meshCollider);
            gameManager.UpdateScore(100);
            Debug.Log("Collider Destroyed!!!");
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Game Over!!!");
            Destroy(collision.gameObject);
            gameManager.GameOver();
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