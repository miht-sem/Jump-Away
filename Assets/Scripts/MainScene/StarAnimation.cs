using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    private SpriteRenderer star;
    public float moveSpeed = 0.1f;
    void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time / 2.5f, 1.0f));

        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }
}
