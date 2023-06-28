using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    [SerializeField] private bool isGronded = false;
    public bool IsGrounded() => isGronded;
    private Collider2D groundCollider = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (groundCollider == null)
        {
            groundCollider = collision.collider;
            isGronded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (groundCollider == collision.collider)
        {
            groundCollider = null;
            isGronded = false;
        }
    }
}
