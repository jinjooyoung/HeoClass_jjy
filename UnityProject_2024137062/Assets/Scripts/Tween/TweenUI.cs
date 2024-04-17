using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();                                  //이미지 컴포넌트를 가져온다.

        image.DOFade(0f, duration)                                      //UI Fade를 한다. 0:투명처리
                .SetEase(Ease.InOutQuad)                                //옵션 값 설정
                .SetAutoKill(false)
                .Pause()
                .OnComplete(() => Debug.Log("UI 완료"));         //익명함수에서 로그 활성화 [() =>]

        image.DOPlay();                                //설정된 트윈을 실행
    }
}
