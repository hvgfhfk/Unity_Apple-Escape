using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Apple")
        {
            GameManager.instance.playerLifeCount--;
            //GameManager.instance.ShieldCount -= 1;
            if (GameManager.instance.playerLifeCount < 1)
            {
                playerDie();
            }
        }
    }

    void playerDie()
    {
        GameManager.instance.DeadOn();
    }
}
