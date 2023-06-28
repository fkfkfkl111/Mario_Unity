using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class triger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") | collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }  
    }
}