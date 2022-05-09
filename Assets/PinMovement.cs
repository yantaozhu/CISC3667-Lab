using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 20;
        rigid.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 

    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "XBoundary")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Balloon")
        {
            Destroy(collision.gameObject);
        }
    }
}
