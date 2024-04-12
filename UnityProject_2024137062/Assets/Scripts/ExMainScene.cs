using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                 //UI ����ϱ� �����߰�
using UnityEngine.SceneManagement;                    //UI �� �Ŵ����� �ϱ����� �߰�
 

public class ExMainScene : MonoBehaviour
{
    public Text PointUI;                              //UI ���� �߰�
    void Start()
    {
        PointUI.text = PlayerPrefs.GetInt("Point").ToString();    //����� ����Ʈ ������ UI ǥ��
    }

    // Update is called once per frame
    public void GoToGame()
    {
        SceneManager.LoadScene("Scenes04_12_shoot");             //���� ������ ����.
    }
}
