using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float characterSpeed = 7.0f;

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
            MoveRight();
            Debug.Log(Input.touchCount);
        }
        else if((Input.touchCount == 0) && (Input.touchCount % 2 == 0))
        {
            Debug.Log(Input.touchCount);
            MoveLeft();
        }
    }

    void MoveRight()
    {
        transform.Translate(characterSpeed * Time.deltaTime, 0, 0);
        anim.SetFloat("right", 1.0f);
        transform.localScale = new Vector2(1, 1);
        Debug.Log("right");
    }

    void MoveLeft()
    {
        transform.Translate(-characterSpeed * Time.deltaTime, 0, 0);
        anim.SetFloat("left", 1.0f);
        transform.localScale = new Vector2(-1, 1);
        Debug.Log("left");
    }

}
