using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Player = null;
    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, 1.3f, -10f), Time.deltaTime * 2);
        }
    }
}
