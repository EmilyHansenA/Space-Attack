using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public GameObject laserPrefab;

    private float fireRate = 0.16f;
    private float nextFire;

    [SerializeField]
    private GameObject playerExplosionPrefab;

    [SerializeField]
    private int playerLives = 5;

    [SerializeField]
    private int speed = 6;

    [SerializeField]
    private AudioSource laserShot;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        laserShot = GetComponent<AudioSource>();
    }

    void Update()
    {
        SpaceMovement();

        //Стрельба
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextFire)
            {
                laserShot.Play();
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
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            SceneManager.LoadScene("GameOver");
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
