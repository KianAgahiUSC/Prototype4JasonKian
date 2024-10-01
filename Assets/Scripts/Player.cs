using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float gunHeat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject obj = Instantiate(bullet, new Vector3(transform.position.x + 0.85f, transform.position.y + 1, 0), transform.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
    }
}
