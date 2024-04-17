using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRayCast : MonoBehaviour
{

    public int Point = 0;                                                 //포인트 계산 변수
    public GameObject TargetObject;                                       //타겟 프리팹
    public float CheckTime = 0;                                           //타겟 Gen 시간 변수
    public float GameTime = 30.0f;

    public Text pointUI;
    public Text timeUI;

    void Update()
    {
        CheckTime += Time.deltaTime;                                      //프레임이 누적되어시간을 계산하게 한다.
        GameTime -= Time.deltaTime;                                       //프레임 시간을 제거하여 30초 ->

        if(GameTime <= 0)                                                 //0초가 되면
        {
            PlayerPrefs.SetInt("Point", Point);                           //유니티에서 제공하는 저장 함수
            SceneManager.LoadScene("MainScene");                         //MainScene으로 이동한다.
        }
         
        pointUI.text = "점수 : " + Point.ToString();                      //UI 점수 표시
        timeUI.text = "남은 시간 : " + GameTime.ToString() + "s";         //UI 잠은 시간 표시


        if(CheckTime >= 0.5f)                                             //0.5초마다 행동을 한다.
        {
            int RandomX = Random.Range(0, 12);                                     //0~11사이의 랜덤값을 뽑아낸다.
            int RandomY = Random.Range(0, 12);                                     //0~11사이의 랜덤값을 뽐아낸다.
            GameObject temp = Instantiate(TargetObject);                              //Instantracte 함수를 통해서 프리팹을 생성한다.    temp가
            temp.transform.position = new Vector3(-6 + RandomX, -6 + RandomY, 0);     //랜덤값을 더해서 -6 ~5 사이의 값을 랜덤하게 배치
            Destroy(temp, 1.0f);                                                      //생성 후 파괴를 1초 후에 해준다.
            CheckTime = 0;                                                           //시간을 초기화 해준다. (0.5초마다 반복하게 하기 위해서)
        } 

        if (Input.GetMouseButtonDown(0))  //마우스 오른쪽 버튼이 눌렸을 경우
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition); //카메라를 화면 시점에서 마우스 포지션에서 Ray를 쏜다.

            RaycastHit hit;                                               //쏜 Ray를 받아오는 변수

            if (Physics.Raycast(cast, out hit))                           //Ray에 검출된것이 있으면
             {
                Debug.Log(hit.collider.gameObject.name);                  //검출된 오브젝트 이름을 출력 해준다.

                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);  //Ray를 라인으로 표현해주는 함수

                if(hit.collider.gameObject.tag == "Target")              //검출된 초브젝트의 Tag가 Target일 경우
                {
                    Point += 1;                                           //파괴 점수 1점을 준다.
                    Destroy(hit.collider.gameObject);                     //해당 게임 오브젝트를 파괴한다.
                }
            }
        }
    }
}
