using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenChange : MonoBehaviour
{
    public bool isPunch = false;                        //연속적으로 입력이 들어오는것을 막기위한 Flag 값

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        //펀치 체크가 false일 경우
        {
            if (!isPunch)
            {
                isPunch = true;                         //펀치 체크를 True로 만들어줘서 계속 입력이 들어가지만 로직을 수행하지 못하게 막는다.
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);    //펀칭효과를 내고 끝나면 EndPunch함수를 호출
            }
        }
        
    }

    void EndPunch()
    {
        isPunch = false;
    }
}
