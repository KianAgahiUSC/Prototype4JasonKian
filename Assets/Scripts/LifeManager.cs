using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public int lives = 3;  
    public TextMeshProUGUI livesText; 
    
    public GameObject gameOverScene; 
    public GameObject startGameText; 

    private bool gameIsOver = false; 
    private bool gameIsStarted = false; 


    void Start()
    {
        UpdateLivesText();
        Time.timeScale = 0;
        startGameText.SetActive(true);
        gameOverScene.SetActive(false);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
{
    // 检查进入 GameOverZone 的物体是否具有 "Enemy" 标签
    if (collision.CompareTag("Enemy"))
    {
        Debug.Log("Enemy hit the GameOverZone");
        
        // 生命值减少
        lives--;
        UpdateLivesText();

        // 如果生命值小于或等于0，执行游戏结束逻辑
        if (lives <= 0)
        {
            GameOver();
        }
    }
}



    
    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }

    void Update()
    {
       
        if (gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }

        
        if (!gameIsStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    
    void StartGame()
    {
        Time.timeScale = 1; 
        startGameText.SetActive(false); 
        gameIsStarted = true; 
    }

    
    void GameOver()
    {
        Time.timeScale = 0; 
        gameOverScene.SetActive(true); 
        gameIsOver = true;
    }

    
    void Restart()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    
}

