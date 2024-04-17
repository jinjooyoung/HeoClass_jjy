using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGen : MonoBehaviour
{
    public GameObject item;                 //게임 오브젝트 아이템 정의
    public float checkTime;                 //시간값 체크 정의

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;        //매 프레임 시간을 더해서 쌓아서
        if (checkTime > 2.0f)               //2초가 지났을 때
        {
            GameObject Temp = Instantiate(item);        //오브젝트를 생성하는 함수 <Instantiate>, GameObject를 임시로 저장할 Temp정의를 선언한다.
            Temp.transform.position += new Vector3(0.0f, Random.Range(0, 4), 0.0f); //랜덤으로 0,3의 값으로 위치를 바꿔준다.
            Destroy(Temp, 20.0f);           //오브젝트를 20초후에 파괴

            checkTime = 0.0f;            //2초마다 아이템을 생성하기 위해서 초기화
        }
    }
}
