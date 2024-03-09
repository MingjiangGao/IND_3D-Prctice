using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Reference to the GameManager instance
    public AnimationManager animationManager;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        GameManager.Instance.ResetGameState();
        animationManager.CrossFadeWhite();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        GameManager.Instance.ResetGameState();
        animationManager.CrossFadeWhite();
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
        animationManager.CrossFadeWhite();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
