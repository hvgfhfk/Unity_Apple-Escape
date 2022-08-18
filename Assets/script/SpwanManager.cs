using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴

    public bool enableSpawn = true; // apple 프리팹 생성 bool 변수
    public GameObject[] apple; // apple prefab을 받을 변수

    private float spawnSpeed = 0.1f;


    void SpawnApple()
    {
        float randomX = Random.Range(-9.33f, 9.3f); // apple이 나타날 x의 랜덤 좌표

        int appleIndex = Random.Range(0, apple.Length);
        // appleIndex 안에 = 랜덤 0부터 배열의 길이까지 담기

        if(enableSpawn)
        {
            Instantiate(apple[appleIndex], new Vector3(randomX, 5.73f, 0f),Quaternion.identity);
        }
    }

    void Spwan()
    {
        InvokeRepeating("SpawnApple", 3, spawnSpeed);
        // Debug.Log("spawnspeed : " + SpawnSpeed);
    }

    private void Start()
    {
        Spwan();
    }
}
