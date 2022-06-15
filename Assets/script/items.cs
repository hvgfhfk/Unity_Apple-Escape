using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class items : MonoBehaviour
{

    public Sprite[] sprite;
    public Image[] image;
    public Button[] button_random;
    public GameObject ShieldPrefab;

    Sprite select;
    int index = 0; // 이미지의 개수
    int maxbomb = 1; // 폭탄 아이템의 최대 개수
    int maxshield = 1; // 쉴드 아이템의 최대 개수

    private void Start()
    {
        Funciton_RandomImage();
    }

    private void Update()
    {
        Button_onClick();
        ShieldActive();
    }

    public void Funciton_RandomImage()
    {

        for (int i = 0; i < 5; i++)
        {
            index = Random.Range(0, sprite.Length);
            select = sprite[index];
           // Debug.Log(sprite[i]);
            for (int y = 0; y < 5; y++)
            {
                image[i].sprite = select; // 아이템 추가
            }
        }
    }

    public void ShieldActive()
    {
        if (GameManager.instance.ShieldCount < 1)
        {
            ShieldPrefab.SetActive(false);
        }
    }

    // 쉴드
    public void ShieldUse()
    {
        GameManager.instance.ShieldCount++;
        GameManager.instance.PlayerLifeCount++;
        ShieldPrefab.SetActive(true);
    }
    // 폭탄
    public void BombUse()
    {
        GameObject[] gameobjects;
        gameobjects = GameObject.FindGameObjectsWithTag("Apple");

        foreach(GameObject objects in gameobjects)
        {
            Destroy(objects); // 현재 씬에 있는 모든 사과를 제거
            maxbomb -= maxbomb;
            Debug.Log(maxbomb);
        }
        
    }

    public void Button_onClick()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 버튼클릭이 아니고 단축키 클릭/
        {
            itemUse(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemUse(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            itemUse(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            itemUse(3);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            itemUse(4);
        }
    }

    public void itemUse(int i)
    {
        if (image[i].sprite == sprite[0]) // image[0] 이  sprite 0 과같음
        {
            if (image[i].gameObject.activeSelf == false)
            {
                Debug.Log("아이템이 없습니다.");
            }
            else
            {
                BombUse();
                image[i].gameObject.SetActive(false);
                Debug.Log("boom / image" + i);
            }
        }
        else if (image[i].sprite == sprite[1])
        {
            if (image[i].gameObject.activeSelf == false)
            {
                Debug.Log("아이템이 없습니다.");
            }
            else
            {
                ShieldUse();
                image[i].gameObject.SetActive(false);
                Debug.Log("shield / image" + i);
            }
        }
        
    }
}
/* 폭탄 : 퀵슬롯에 등록되어있는 키 1~5번중 폭탄이 있는 슬롯을 클릭하면
 화면에 있는 모든 사과를 제거한다.

   쉴드 : 캐릭터 주변에 쉴드를 장착해 사과가 떨어져 캐릭터 충돌을 한번 방어
*/