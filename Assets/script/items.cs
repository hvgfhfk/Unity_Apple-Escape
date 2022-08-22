using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class items : MonoBehaviour
{

    public Sprite[] sprite;
    public Image[] image;
    public Button[] buttonRandom;
    public GameObject shieldPrefab;

    Sprite select;
    int imageIndex = 0; // 이미지의 개수
    int maxBombCount = 1; // 폭탄 아이템의 최대 개수

    private void Start()
    {
        AddItemRandomLocation();
    }

    private void Update()
    {
        ButtonOnClick();
        ShieldActive();
    }

    public void AddItemRandomLocation()
    {

        for (int i = 0; i < 5; i++)
        {
            imageIndex = Random.Range(0, sprite.Length);
            select = sprite[imageIndex];
           // Debug.Log(sprite[i]);
            for (int y = 0; y < 5; y++)
            {
                image[i].sprite = select; // 아이템 추가
            }
        }
    }

    public void ShieldActive()
    {
        if (GameManager.instance.shieldCount < 1)
        {
            shieldPrefab.SetActive(false);
        }
    }

    // 쉴드
    public void ShieldUse()
    {
        GameManager.instance.shieldCount++;
        GameManager.instance.playerLifeCount++;
        shieldPrefab.SetActive(true);
    }
    // 폭탄
    public void BombUse()
    {
        GameObject[] gameobjects;
        gameobjects = GameObject.FindGameObjectsWithTag("Apple");

        foreach(GameObject objects in gameobjects)
        {
            Destroy(objects); // 현재 씬에 있는 모든 사과를 제거
            maxBombCount -= maxBombCount;
            Debug.Log(maxBombCount);
        }
        
    }

    public void ButtonOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 버튼클릭이 아니고 단축키 클릭/
        {
            ItemUse(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ItemUse(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ItemUse(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ItemUse(3);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            ItemUse(4);
        }
    }

    public void ItemUse(int imageCount)
    {
        if (image[imageCount].sprite == sprite[0]) // image[0] 이  sprite 0 과같음
        {
            if (image[imageCount].gameObject.activeSelf == false)
            {
                Debug.Log("아이템이 없습니다.");
            }
            else
            {
                BombUse();
                image[imageCount].gameObject.SetActive(false);
                Debug.Log("boom / image" + imageCount);
            }
        }
        else if (image[imageCount].sprite == sprite[1])
        {
            if (image[imageCount].gameObject.activeSelf == false)
            {
                Debug.Log("아이템이 없습니다.");
            }
            else
            {
                ShieldUse();
                image[imageCount].gameObject.SetActive(false);
                Debug.Log("shield / image" + imageCount);
            }
        }
        
    }

}