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
        //Move();
        ClickCount();
    }

    void ClickCount()
    {

        if(Input.touchCount % 2 == 1)
        {
            moveRight();
            Debug.Log(Input.touchCount);

        }
        else if((Input.touchCount == 0) && (Input.touchCount % 2 == 0))
        {
            Debug.Log(Input.touchCount);
            moveLeft();
        }
    }

    void moveRight()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        anim.SetFloat("right", 1.0f);
        transform.localScale = new Vector2(1, 1);
        Debug.Log("right");
    }

    void moveLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        anim.SetFloat("left", 1.0f);
        transform.localScale = new Vector2(-1, 1);
        Debug.Log("left");
    }

    void Move()
    {
       // ClickCount();
       // if (GametouchCount % 2 == 1)
        //{
            //Debug.Log("right");
       // }
       // else if ((GametouchCount == 0) && (GametouchCount % 2 == 0))
       // {
            // Debug.Log("left");
       // }
        //Vector3 moveV = Vector3.zero;

        /*if (Input.GetAxisRaw("Horizontal") < 0)
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
        }*/

        //transform.position += moveV * speed * Time.deltaTime;
    }

}
