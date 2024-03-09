using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_SceneManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       UpdateScore();
    }
    void UpdateScore(){
         if(GameManager.Instance != null && scoreText != null){
            score = GameManager.Instance.score;
            scoreText.text = score.ToString();
        }
    }
}
