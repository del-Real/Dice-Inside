using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] List<GameObject> dices;
    [SerializeField] bool isGameActive;
    [SerializeField] int spawnRate;

    private Vector3 spawnPosition = new Vector3(0, 6.2f, 45f);
    private float[] spawnRotation = { 90f, 180f, 270f };

    void Start() {
        isGameActive = true;
        StartCoroutine(SpawnDice());
    }


    IEnumerator SpawnDice() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int diceIndex = Random.Range(0, dices.Count);
            int rotationIndex = Random.Range(0, spawnRotation.Length);
            Instantiate(dices[diceIndex], spawnPosition, Quaternion.Euler(spawnRotation[rotationIndex], 0f, 0f));
        }

    }
}
