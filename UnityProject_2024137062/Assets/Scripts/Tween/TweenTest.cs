using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                                      //DoTween을 사용하기 위해

public class TweenTest : MonoBehaviour
{
    Tween tween;
    Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        //transform.DOMoveX(5, 0.5f);                        //Tween을 통해서 오브젝트는 x축으로 0.5초동안 5만큼 간다.
        //transform.DORotate(new Vector3 (0, 0, 180), 0.3f);       ////Tween을 통해서 오브젝트는 z축으로 0.3초동안 180도 만큼 회전한다.
        //transform.DOScale(new Vector3(2, 2, 2), 2);          //Tween을 통해서 오브젝트는 2초동안 2배(부피 8배)로 커진다.

        /*Sequence sequence = DOTween.Sequence();                 //시퀀스를 생성한다. (앞의 트윈이 끝나면 다음 트윈이 시작된다.
        sequence.Append(transform.DOMoveX(5, 0.5f));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 0.3f));
        sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));*/

        /*transform.DOMoveX(5, 2f).SetEase(Ease.OutBounce).OnComplete(DeactivateObject);             //이동할때 효과를 추가 시킬 수 있다
        transform.DOShakeRotation(2f, new Vector3(0, 0, 5), 10, 90);  //이동하는 동안 회전 충격 효과*/

        sequence = DOTween.Sequence();             //시퀸스 생성
        sequence.Append(transform.DOMoveX(5, 2f));          //움직임 추가
        sequence.SetLoops(-1, LoopType.Yoyo);               //루프를 돌리기위한 옵션들 설정
    }

    void DeactivateObject()                     //연출이 종료된 이후에 함수를 호출
    {
        gameObject.SetActive(false);            //오브젝트를 끈다 (보이지 않지만 존재는 함)
        Debug.Log("연출 종료");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //스페이스바를 누르면
        {
            sequence.Kill();                    //해당 시퀀스 종료
            //tween.Kill();                     //해당 트윈을 종료한다
        }
    }
}
