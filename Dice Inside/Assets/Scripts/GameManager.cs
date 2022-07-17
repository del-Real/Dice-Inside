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

    private RollingDice rollingDice;
    private Vector3 spawnPosition;
    private float[] spawnRotation = { 90f, 180f, 270f };
    private int score;
    private Quaternion[] diceFaces = {
        Quaternion.Euler(0,0,0),
        Quaternion.Euler(90,0,0),
        Quaternion.Euler(180,90,90),
        Quaternion.Euler(180,90,-90),
        Quaternion.Euler(-90,0,0),
        Quaternion.Euler(-180,0,0),
    };

    void Start() {
        rollingDice = dice.GetComponent<RollingDice>();
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
        isGameActive = true;
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            spawnPosition = new Vector3(0f, 11.5f, Random.Range(70f, 75f));
            int randomFace = Random.Range(0, 5);
            Debug.Log(randomFace + 1);
            Quaternion diceFace = diceFaces[randomFace];
            rollingDice.IncreaseRandomSpeed();
            Instantiate(dice, spawnPosition, diceFace);
        }

    }
}