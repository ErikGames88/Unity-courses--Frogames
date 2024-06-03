using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Library to use TextMEshPro
using UnityEngine.UI; //Library to use the USer Interface
using UnityEngine.SceneManagement; //Library to can manage the scenes

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }
    public GameState gameState;

    public List <GameObject> targetPrefabs;

    private float spawnRange = 2.0f;

    [SerializeField] TextMeshProUGUI scoreText; //Variable which will be the place where to write

    private int score; //Variable which will be the value to write
    private int Score
    {
        set
        {
            score = Mathf.Clamp(value, 0, 9999);
        }
        get
        {
            return score;
        }
    }

    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartButton;

    private int fallCount = 0;
    public int FallCount
    {
        get => fallCount;
        set => fallCount = value;
    }

    [SerializeField] GameObject tittleScreen;

    private int numberOfLifes = 4;
    
    /// <summary>
    /// To start the departure changing the game mode
    /// </summary>
    /// <param name="difficulty"> Integer number which setting the difficulty level </param>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        tittleScreen.gameObject.SetActive(false);

        spawnRange /= difficulty;
        numberOfLifes -= difficulty;   

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRange);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    /// <summary>
    /// Updating the score and showing it on screen
    /// </summary>
    /// <param name="scoreToAdd"> Number of points added for the global score </param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "SCORE: \n" + Score; // \n --> new line (intro) in the text
    }

    public void GameOver()
    {
        if (numberOfLifes <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            gameState = GameState.gameOver;
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //To memorise to laad the active scene by name
    }
}
