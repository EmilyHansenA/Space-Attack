using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject laserPrefab;

    private float fireRate = 0.16f;
    private float nextFire;

    [SerializeField]
    private int playerLives = 5;
    private int speed = 6;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        SpaceMovement();

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            }
        }
    }

    public void LifeCount()
    {
        playerLives--;

        if(playerLives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void SpaceMovement()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        
    //Границы вертикали
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
    //Границы горизонтали
        if (transform.position.x > 10f)
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }

        else if (transform.position.x < -10f)
        {
            transform.position = new Vector3(10f, transform.position.y, 0);
        }
    }
}
