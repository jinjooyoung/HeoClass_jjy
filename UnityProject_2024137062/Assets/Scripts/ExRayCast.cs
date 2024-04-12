using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRayCast : MonoBehaviour
{

    public int Point = 0;                                                 //����Ʈ ��� ����
    public GameObject TargetObject;                                       //Ÿ�� ������
    public float CheckTime = 0;                                           //Ÿ�� Gen �ð� ����
    public float GameTime = 30.0f;

    public Text pointUI;
    public Text timeUI;

    void Update()
    {
        CheckTime += Time.deltaTime;                                      //�������� �����Ǿ�ð��� ����ϰ� �Ѵ�.
        GameTime -= Time.deltaTime;                                       //������ �ð��� �����Ͽ� 30�� ->

        if(GameTime <= 0)                                                 //0�ʰ� �Ǹ�
        {
            PlayerPrefs.SetInt("Point", Point);                           //����Ƽ���� �����ϴ� ���� �Լ�
            SceneManager.LoadScene("MainScene");                         //MainScene���� �̵��Ѵ�.
        }
         
        pointUI.text = "���� : " + Point.ToString();                      //UI ���� ǥ��
        timeUI.text = "���� �ð� : " + GameTime.ToString() + "s";         //UI ���� �ð� ǥ��


        if(CheckTime >= 0.5f)                                             //0.5�ʸ��� �ൿ�� �Ѵ�.
        {
            int RandomX = Random.Range(0, 12);                                     //0~11������ �������� �̾Ƴ���.
            int RandomY = Random.Range(0, 12);                                     //0~11������ �������� �˾Ƴ���.
            GameObject temp = Instantiate(TargetObject);                              //Instantracte �Լ��� ���ؼ� �������� �����Ѵ�.    temp��
            temp.transform.position = new Vector3(-6 + RandomX, -6 + RandomY, 0);     //�������� ���ؼ� -6 ~5 ������ ���� �����ϰ� ��ġ
            Destroy(temp, 1.0f);                                                      //���� �� �ı��� 1�� �Ŀ� ���ش�.
            CheckTime = 0;                                                           //�ð��� �ʱ�ȭ ���ش�. (0.5�ʸ��� �ݺ��ϰ� �ϱ� ���ؼ�)
        } 

        if (Input.GetMouseButtonDown(0))  //���콺 ������ ��ư�� ������ ���
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition); //ī�޶� ȭ�� �������� ���콺 �����ǿ��� Ray�� ���.

            RaycastHit hit;                                               //�� Ray�� �޾ƿ��� ����

            if (Physics.Raycast(cast, out hit))                           //Ray�� ����Ȱ��� ������
             {
                Debug.Log(hit.collider.gameObject.name);                  //����� ������Ʈ �̸��� ��� ���ش�.

                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);  //Ray�� �������� ǥ�����ִ� �Լ�

                if(hit.collider.gameObject.tag == "Target")              //����� �ʺ���Ʈ�� Tag�� Target�� ���
                {
                    Point += 1;                                           //�ı� ���� 1���� �ش�.
                    Destroy(hit.collider.gameObject);                     //�ش� ���� ������Ʈ�� �ı��Ѵ�.
                }
            }
        }
    }
}
