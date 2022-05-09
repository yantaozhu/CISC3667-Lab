using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float horizontalMovement;
    [SerializeField] float verticalMovement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] int speed;
    [SerializeField] GameObject Pin;
    [SerializeField] float fireRate = 1f;
    [SerializeField] Animator animator;
    private float nextFire = 0.0f;
    const int IDLE = 0;
    const int RUN = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        speed = 10;
        transform.position = new Vector3(0,0,0);
        animator.SetInteger("motion", IDLE);
        animator.SetBool("shot", false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        if (Time.time > nextFire)
        {
            animator.SetBool("shot", false);
            if (Input.GetKeyDown("space"))
            {
                nextFire = Time.time + fireRate;
                animator.SetBool("shot", true);
                Shot();
            }
        }
        if (horizontalMovement >= 0.1 || horizontalMovement <= -0.1)
            animator.SetInteger("motion", RUN);
        else
            animator.SetInteger("motion", IDLE);
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector3(horizontalMovement * speed, verticalMovement * speed, 0);
        if (horizontalMovement < 0 && isFacingRight || horizontalMovement > 0 && !isFacingRight)
            Flip();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Shot()
    {
        Instantiate(Pin, transform.position, transform.rotation);
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "XBoundary")
        {
            horizontalMovement = 0;
        }
        if (collision.gameObject.tag == "YBoundary")
        {
            verticalMovement = 0;
        }
    }
}
