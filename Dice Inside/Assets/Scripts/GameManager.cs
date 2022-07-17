using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] GameObject dice;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] bool isGameActive;
    [SerializeField] int spawnRate;
    [SerializeField] Text scoreText;

    private Vector3 spawnPosition = new Vector3(0, 11.5f, 75f);
    private float[] spawnRotation = { 90f, 180f, 270f };
    private int score;

    void Start() {
        StartGame();
    }

    public void StartGame() {
        isGameActive = true;
        UpdateScore(0);
        StartCoroutine(SpawnDice());
    }

    public void GameOver() {
        isGameActive = false;
        gameOverMenu.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score\n" + score;
    }


    IEnumerator SpawnDice() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int rotationIndex = Random.Range(0, spawnRotation.Length);
            Instantiate(dice, spawnPosition, Quaternion.Euler(spawnRotation[rotationIndex], 0f, spawnRotation[rotationIndex]));
        }

    }
}
