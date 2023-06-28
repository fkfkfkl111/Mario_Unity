using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public int rotation = 1;
    
    Rigidbody2D rb;
    [SerializeField] GameObject droppedPrefab = null;
    void Start()
    {
        
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        
    }
    
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Ground"))
        {
            speed = -speed;
            rotation = -rotation;
            transform.localScale = new Vector2(rotation, 1);
        }
        if (collision.CompareTag("Player"))
        {
            if (droppedPrefab != null)
            {
                Instantiate(droppedPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
    
}
