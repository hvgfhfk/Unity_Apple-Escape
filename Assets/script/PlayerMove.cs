using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 7.0f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    void Move()
    {
        Vector3 moveV = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveV = Vector3.left;
            anim.SetFloat("left", 1.0f);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveV = Vector3.right;
            anim.SetFloat("right", 1.0f);
        }
        else
        {
            anim.SetFloat("left", -1f);
            anim.SetFloat("right", -1f);
        }

        transform.position += moveV * speed * Time.deltaTime;
    }

}
