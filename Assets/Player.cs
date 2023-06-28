using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    [SerializeField] private float jump = 6, maxspeed = 10;
    private ground Ground = null;
    private Animator animator;
    [SerializeField] private int maxJumps = 1;
    private const int noJump = 0, jumpRise = 1, jumpFall = 2;
    private int jumps = 0;

    private bool IsTimer = false, y = false, y1 = false, y2 = false, IsUse = false;
    public float mili = 0, sec = 0, x = 30, x1 = 20, x2 = 10;
    [SerializeField] GameObject droppedPrefab = null;
    //public GameObject model1, model2;
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Ground = GetComponentInChildren<ground>();
    }
    private bool doJump = false;
    void Update()
    {
        
        doJump |= (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && jumps < maxJumps;
    }
    private void FixedUpdate()
    {
        if (IsTimer)
        {
            mili += 0.02f;
            if(mili >= 1)
            {
                sec++;
                mili = 0;
            }
            if (sec >= x && y)
            {
                //model1.transform.SetParent(transform);
                //model2.transform.SetParent(null);
                transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
                jump -= 2;
                sec = 0;
                IsTimer = false;
                y = false;
                IsUse = false;
            }
            if (sec >= x1 && y1)
            {
                //model1.transform.SetParent(transform);
                //model2.transform.SetParent(null);
                transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
                jump += 1;
                sec = 0;
                IsTimer = false;
                y1 = false;
                IsUse = false;
            }
            if (sec >= x2 && y2)
            {
                //model1.transform.SetParent(transform);
                //model2.transform.SetParent(null);
                transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
                jump -= 3;
                sec = 0;
                IsTimer = false;
                y2 = false;
                IsUse = false;
            }


        }

        Vector2 motion = rbody2D.velocity;
        if (doJump)
        {
            doJump = false;
            motion.y = jump;
            animator.SetInteger("jumpState", jumpRise);
            jumps++;
        }
        if (Ground.IsGrounded() == false)
        {
            animator.SetInteger("jumpState", jumpFall);
        }
        if (Ground.IsGrounded() == true)
        {
            animator.SetInteger("jumpState", noJump);
            jumps = 0;
        }
        var input = Input.GetAxis("Horizontal");

        if (input == 0)
        {
            animator.SetBool("IsWalk", false);
        }
        else
        {
            animator.SetBool("IsWalk", true);
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(input);
            transform.localScale = scale;
        }
        animator.SetBool("IsWalk", input != 0);

        motion.x = input * maxspeed;
        rbody2D.velocity = motion;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (droppedPrefab != null)
            {
                Instantiate(droppedPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        if (collision.CompareTag("SuperScaleBuff") && IsUse == false)
        {
            //model2.transform.SetParent(transform);
            //model1.transform.SetParent(null);
            transform.localScale = new Vector3(4.5f, 4.5f, transform.localScale.z);
            jump += 3;
            IsTimer = true;
            y2 = true;
            IsUse = true;

        }
        if (collision.CompareTag("ScaleUnbuff") && IsUse == false)
        {
            //model2.transform.SetParent(transform);
            //model1.transform.SetParent(null);
            transform.localScale = new Vector3(0.5f, 2f, transform.localScale.z);
            jump -= 1;
            IsTimer = true;
            y1 = true;
            IsUse = true;
        }
        if (collision.CompareTag("ScaleBuff") && IsUse == false)
        {
            //model2.transform.SetParent(transform);
            //model1.transform.SetParent(null);
            transform.localScale = new Vector3(1.5f, 1.5f, transform.localScale.z);
            jump += 2;
            IsTimer = true;
            y = true;
            IsUse = true;
        }
    }
}
