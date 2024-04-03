using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExPlayer : MonoBehaviour
{
    public Rigidbody m_RigidBody;         //리지드바디를 소스로 사용하게 받아 온다.
    public int Force = 100;             //int 정수로 힘을 100으로 설정한다.
    public int point = 0;               //점수 사용할 변수 추가
    public float checkTime = 0;         //시간 측정을 위한 변수 (소수점)
    public Text m_Text;                 //UI텍스트 접근

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //마우스 입력이 들어왔을 때
        {
            m_RigidBody.AddForce(transform.up * Force);       //transform.up(위쪽 방향)으로 리지드 바디에 Force 힘만큼 물리의 힘을 준다.
        }

        checkTime += Time.deltaTime;                //프레임 시작을 더해서 시간을 측정
        if(checkTime >= 1.0f)                       //만약 1초가 지났을 경우
        {
            point += 1;                             //1점씩 더해준다
            checkTime = 0.0f;                       //1초가 지날경우 초기화
        }

        m_Text.text = point.ToString();             //UI표시
    }

    private void OnCollisionEnter(Collision collision)      //충돌이 시작 되었을 때
    {
        if(collision != null)                               //충돌 물체가 존재할 경우
        {
            point = 0;                                  //충돌이 일어났을 때 포인트를 0으로 만든다.
            gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);      //충돌하였을 때 위치 초기화
            Debug.Log(collision.gameObject.tag);       //해당 오브젝트의 이름을 출력한다

        }
    }

    //콜라이더 컴포넌트에 is trigger 를 체크하면 충돌 물리효과는 없어지지만 닿은것을 확인 할 수 있음

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))       //CompareTag 함수는지어진 Tag(Item) 이름을 검사한다.
        {
            Debug.Log("아이템과 출동함.");
            point += 10;                    //10점 포인트를 올린다. point = point + 10의 줄임표현
            Destroy(other.gameObject);      //파괴한다.
        }
    }
}
