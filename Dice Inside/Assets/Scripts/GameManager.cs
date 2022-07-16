using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] GameObject dice;
    [SerializeField] bool isGameActive;
    [SerializeField] int spawnRate;

    private Vector3 spawnPosition = new Vector3(0, 10f, 75f);
    private float[] spawnRotation = { 90f, 180f, 270f };

    void Start() {
        isGameActive = true;
        SpawnDice();
        StartCoroutine(SpawnDice());
    }


    IEnumerator SpawnDice() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int rotationIndex = Random.Range(0, spawnRotation.Length);
            Instantiate(dice, spawnPosition, Quaternion.Euler(spawnRotation[rotationIndex], 0f, 0f));
        }

    }
}
