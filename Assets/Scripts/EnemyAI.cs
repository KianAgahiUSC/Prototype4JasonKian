using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.Build;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //public GameObject player;
    public float speed;
    private float distance;
    public GameObject prefab;

    public GameObject player;

    public Player playerScript;

    private int enemyKilled;

    public GameObject game;
    public Game gameScript;


    public 

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
        game = GameObject.Find("GameSystem");
        playerScript = player.GetComponent<Player>();
        gameScript = game.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x, -10), speed * Time.deltaTime);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log(gameScript.enemyKilled);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            playerScript.playerPower -= 2 * Time.deltaTime;
            playerScript.playerPower = Mathf.Max(playerScript.playerPower, 0.05f);
            gameScript.enemyKilled++;

            if (gameScript.enemyKilled >= 10)
            {
                gameScript.enemyKilled = 0;
                playerScript.bulletNum += 2;
            }
        }
    }
}
