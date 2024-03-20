using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExTest : MonoBehaviour
{
    public float age;         //변수 int(정수형) age 라는 이름으로 선언

    // Start is called before the first frame update
    void Start()
    {
        //age = 30;           //변수에 30을 입력
        Debug.Log(age);     //변수를 Debug.Log 함수를 통해서 출력한다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
