using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //public GameObject player;
    public float speed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log("COLLISION!");
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }
}
