using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game_SceneManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public float gameTime = 100f;
    public Text timerText;

    public GunControl gunControl;
    public float bulletSpeed;
    public Text bulletSpeedtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        UpdateTimerText();
        UpdateBulletSpeed();
    }
    
    void UpdateScoreText()
    {   
        if (GameManager.Instance != null && scoreText != null){
            score = GameManager.Instance.score;
            scoreText.text = "Score: " + score;
        }
    }

    void UpdateTimerText()
    {
        if (GameManager.Instance != null && timerText != null){
            gameTime = GameManager.Instance.gameTime;
            timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();
        }
    }
    
    void UpdateBulletSpeed(){
        if(gunControl != null){
            bulletSpeed = gunControl.bulletSpeed;
            bulletSpeedtext.text = "Force: " + bulletSpeed;
        }
    }
}
