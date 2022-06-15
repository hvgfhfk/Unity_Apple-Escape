using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴
    public GameObject GameOverText;
    public Text AppleCountText; // 피한 사과의 개수 Text
    public int AppleCount = 0;

    public int ShieldCount = 0;

    public int PlayerLifeCount = 1;
    public bool GameOver = false;

    private void Awake()
    {
        if (null == instance)
            instance = this;
    }

    private void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            GameOver = false;
            Time.timeScale = 1; // 씬을 재실행 할 경우 게임을 재 실행
        }
    }

    public void DeadOn()
    {
        Time.timeScale = 0; // 게임 일시 정지
        GameOver = true;
        GameOverText.SetActive(true);
    }

    public void CountText() // 사과 피한 갯수
    {
        AppleCount += 1; 
        GameManager.instance.AppleCountText.text = "Apple : " + AppleCount;
    }

}
