using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TweenColor : MonoBehaviour
{
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();    //��������Ʈ �� �ڽ� ������Ʈ���� ������Ʈ (������)�� �˻��Ͽ� �����´�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Color color = new Color(Random.value, Random.value, Random.value);  //���� �÷� ����

            renderer.material.DOColor(color, 1f)                        //���� ������ �÷��� Ʈ����
                .SetEase(Ease.InOutQuad)                                //�ɼ� �� ����
                .SetAutoKill(false)
                .Pause()
                .OnComplete(() => Debug.Log("�÷� ��ȯ �Ϸ�"));         //�͸��Լ����� �α� Ȱ��ȭ [() =>]

            renderer.material.DOPlay();                                 //������ Ʈ���� ����
        }
    }
}