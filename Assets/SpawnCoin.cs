using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject Coin;
    public Transform Spawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(Coin, Spawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
