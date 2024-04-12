using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                 //UI 사용하기 위해추가
using UnityEngine.SceneManagement;                    //UI 씬 매니팅을 하기위해 추가
 

public class ExMainScene : MonoBehaviour
{
    public Text PointUI;                              //UI 변수 추가
    void Start()
    {
        PointUI.text = PlayerPrefs.GetInt("Point").ToString();    //저장된 포인트 점수를 UI 표시
    }

    // Update is called once per frame
    public void GoToGame()
    {
        SceneManager.LoadScene("Scenes04_12_shoot");             //게임 씬으로 들어간다.
    }
}
