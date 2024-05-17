using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] CircleObject;                 // 과일 프리팹 오브젝트
    public Transform GenTransform;                  // 과일이 생성될 위치 오브젝트
    public float timeCheck;                         // 시간을 체크하기 위한 플롯 값
    public bool isGen;                              // 생성 완료 체크 불 값

    // Start is called before the first frame update
    void Start()
    {
        GenObject();                                            // 게임이 시작되었을 때 함수를 호출해서 초기화 시킨다.
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGen)     // if (isGen == false) 랑 같은 의미
        {
            timeCheck -= Time.deltaTime;                                // 매 프레임마다 프레임 시간을 빼준다.
            if (timeCheck <= 0 )                                        // 해당 초 시간이 지났을 경우 (1초 -> 0초가 되었을 경우)
            {
                int RandNumber = Random.Range(0, 3);                    // 0 ~ 2까지의 랜덤한 숫자를 생성
                GameObject Temp = Instantiate(CircleObject[RandNumber]);            // 과일 프리팹 오브젝트를 생성시켜준다. Instantiate()
                Temp.transform.position = GenTransform.position;        // 설정한 위치로 이동 시킨다.
                isGen = true;                                           // Gen이 되었다고 true로 bool값을 변경한다.
            }
        }
    }

    public void GenObject()
    {
        isGen = false;                  // 초기화 : isGen을 false (생성되지 않았다)
        timeCheck = 1.0f;               // 1초후 과일 프리팹을 생성 시키기 위한 초기화
    }

    public void MergeObject(int index, Vector3 position)      // Merge 함수는 과일번호(int) 와 생성 위치 값(Vector3)를 전달 받는다.
    {
        GameObject Temp = Instantiate(CircleObject[index]);         // index를 그대로 쓴다. (0부터 배열이 시작되지만 index 값을 1부터 써두었기 때문에)
        Temp.transform.position = position;                         // 위치는 전달 받은 값으로 사용
        Temp.GetComponent<CircleObject>().Used();                   // 선언한 Used 함수 사용
    }
}
