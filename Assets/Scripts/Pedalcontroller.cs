using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedalcontroller : MonoBehaviour
{
    public float speed;
    private float batas = 7.3f;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(Vector3.right * move);
        if (transform.position.x > batas)
        {
            transform.position = new Vector2(batas, transform.position.y);
        }
        if (transform.position.x < -batas)
        {
            transform.position = new Vector2(-batas, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peluru"))
        {
            gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
