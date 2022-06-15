using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneCollision : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Apple")
        {
            GameManager.instance.CountText(); // 카운트 텍스트
        }
    }
}
