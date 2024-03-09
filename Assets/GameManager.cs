using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreText2;
    public int score = 3;
// timer
    public Text timerText;  
    public float gameTime = 100f;
    private bool gameIsFrozen = false;

    //frozen
    public Transition transition;

    public bool IsGameFrozen()
    {
        return gameIsFrozen;
    }
    //restart

    // Start is called before the first frame update

    // Make sure the it functions all the time during scene switching
    public static GameManager Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Scene Switching
    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    public void SwitchToGame(){
        SwitchToScene("Game");
        ResetGameState();

    }
    public void SwitchToLoad(){
        SwitchToScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
    }
    void Start()
    {
        ResetGameState();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
         if (!gameIsFrozen)
        {
            gameTime -= Time.deltaTime;
            gameTime = Mathf.Max(gameTime, 0f);
            UpdateTimerText();

            if (gameTime <= 0f)
            {
                // Game timeout, freeze the game
                gameIsFrozen = true;
                // Show restart page (you can implement this part as needed)
                ShowRestartPage();
            }
        }
    }
    IEnumerator Countdown()
    {
        while (gameTime > 0f)
        {
            yield return null;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();
        }
    }

    void ShowRestartPage()
    {
          // Activate the restart page
        if (gameIsFrozen)
        {
            transition.LoadGameOver();
            Cursor.lockState = CursorLockMode.None;
        }
        // but now I use the scene change not the canva in 3D
    }
    // This is usesless not because I don't use the canva anymore
    //public void RestartGame()
    //{
     //   UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    //}

    public void BulletHitTarget(int targetValue)
    {
        if (targetValue > 0)
        {
            // Bullet hit a target
            score += 3;
        }
        else
        {
            // Bullet did not hit a target
            score -= 1;
        }
        UpdateScoreText();
    }
     void UpdateScoreText()
{
    if (scoreText != null)
    {
        scoreText.text = "Score: " + score;
        scoreText2.text = scoreText.text;
        Debug.Log("Score updated: " + scoreText2.text);
    }
    else
    {
        Debug.LogWarning("scoreText2 is null!");
    }
}

public void ResetGameState()
{
    gameTime = 100f;
    score = 0;
    UpdateScoreText();
    UpdateTimerText();
    gameIsFrozen = false; // Ensure the game is not frozen
    StopAllCoroutines(); // Stop any existing countdown coroutine
    StartCoroutine(Countdown()); // Restart the countdown timer
    Debug.Log("Restart the game!");
}


}
