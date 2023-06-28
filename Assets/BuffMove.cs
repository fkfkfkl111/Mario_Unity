using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMove : MonoBehaviour
{
    public float speed = 2;
    void Start()
    {
        
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag != ("Islands"))
        {
            speed = 0;
        }
    }
}
