using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int ballForce;
    Rigidbody2D rb;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized;
        rb.AddForce(arah * ballForce * 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Pedal")
        {
            float sudut = (transform.position.y - collision.transform.position.y) * 30f;
            Vector2 arah = new Vector2(rb.velocity.x, sudut).normalized;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(arah * ballForce * 2);
        }
        if(collision.gameObject.name == "Border Bawah")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Score 3"))
        {
            Destroy(collision.gameObject);
            gameManager.UpdateScore(3);
        }
        if (collision.gameObject.CompareTag("Score 4"))
        {
            Destroy(collision.gameObject);
            gameManager.UpdateScore(4);
        }
    }
}
