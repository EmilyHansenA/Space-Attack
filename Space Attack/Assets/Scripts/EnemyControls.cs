using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private int enemySpeed = 2;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);

        if (transform.position.y < -6.7f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 6.7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if(playerControls != null)
            {
                playerControls.LifeCount();
            }

            Destroy(this.gameObject);
        }
    }
}
