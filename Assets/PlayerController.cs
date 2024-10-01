using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverScene; 
    public GameObject startGameText; 

    private bool gameIsOver = false; 
    private bool gameIsStarted = false; 

    void Start()
    {
        
        Time.timeScale = 0;
        startGameText.SetActive(true);
        gameOverScene.SetActive(false); 
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

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.tag == "GameOverZone")
        {
            GameOver(); 
        }
    }
}