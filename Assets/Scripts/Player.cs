using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject player;

    private float gunHeat = 0;

    public float playerPower;

    public int bulletNum;

    // Start is called before the first frame update
    void Start()
    {
        playerPower = 2;
        bulletNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gunHeat -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && (gunHeat <= 0))
        {
            Shoot(bulletNum, 60f);
            gunHeat = 0.25f;
        }
        //Debug.Log(playerPower);
    }

    void Shoot(int numberOfBullets, float spreadAngle)
    {
        // Convert spread angle from degrees to radians
        float spreadAngleRadians = spreadAngle * Mathf.Deg2Rad;

        // The angle between each bullet in radians
        float angleStep = numberOfBullets > 1 ? spreadAngleRadians / (numberOfBullets - 1) : 0;
        float startingAngle = numberOfBullets > 1 ? -spreadAngleRadians / 2 : 0; // Start at 0 for a single bullet

        for (int i = 0; i < numberOfBullets; i++)
        {
            // Calculate the current angle in radians
            float currentAngle = startingAngle + i * angleStep;

            // Calculate the direction vector based on the angle
            Vector2 bulletDirection = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle));

            // Instantiate the bullet
            GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);

            // Set the bullet's velocity based on the calculated direction
            obj.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * 15; // Adjust speed as needed
        }
    }

}
