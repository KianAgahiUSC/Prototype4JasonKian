using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    public float shootCooldown = 0.5f; // Cooldown time in seconds
    private float lastShotTime; // Time of the last shot

    void Start()
    {
        lastShotTime = -shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= (lastShotTime + shootCooldown))
        {
            Shoot();
            lastShotTime = Time.time; // Update the time of the last shot
        }

    }

    void Shoot()
    {
        GameObject obj = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y + 1, 0), transform.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
    }
}
