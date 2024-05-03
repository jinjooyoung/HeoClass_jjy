using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CircleObject;                 // ���� ������ ������Ʈ
    public Transform GenTransform;                  // ������ ������ ��ġ ������Ʈ
    public float timeCheck;                         // �ð��� üũ�ϱ� ���� �÷� ��
    public bool isGen;                              // ���� �Ϸ� üũ �� ��

    // Start is called before the first frame update
    void Start()
    {
        GenObject();                                            // ������ ���۵Ǿ��� �� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��.
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGen)     // if (isGen == false) �� ���� �ǹ�
        {
            timeCheck -= Time.deltaTime;                                // �� �����Ӹ��� ������ �ð��� ���ش�.
            if (timeCheck <= 0 )                                        // �ش� �� �ð��� ������ ��� (1�� -> 0�ʰ� �Ǿ��� ���)
            {
                GameObject Temp = Instantiate(CircleObject);            // ���� ������ ������Ʈ�� ���������ش�. Instantiate()
                Temp.transform.position = GenTransform.position;        // ������ ��ġ�� �̵� ��Ų��.
                isGen = true;                                           // Gen�� �Ǿ��ٰ� true�� bool���� �����Ѵ�.
            }
        }
    }

    public void GenObject()
    {
        isGen = false;                  // �ʱ�ȭ : isGen�� false (�������� �ʾҴ�)
        timeCheck = 1.0f;               // 1���� ���� �������� ���� ��Ű�� ���� �ʱ�ȭ
    }
}
