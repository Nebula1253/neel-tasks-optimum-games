using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    private float speed, roadHeight;
    private GameObject road;

    // Start is called before the first frame update
    void Start()
    {
        road = GameObject.Find("Track");
        roadHeight = road.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > (road.transform.position.y + roadHeight))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            road.GetComponent<Track>().speedDecrease();
            Destroy(gameObject);
        }
    }
}
