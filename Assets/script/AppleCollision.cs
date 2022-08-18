using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            Destroy(this.gameObject); // 사과 삭제
        }
        else if(other.gameObject.tag == "Shield")
        { 
            GameManager.instance.shieldCount--;
            Destroy(this.gameObject); // 쉴드에 맞았을 경우 삭제
        }
    }


}
