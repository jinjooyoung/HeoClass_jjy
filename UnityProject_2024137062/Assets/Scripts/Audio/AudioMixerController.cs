using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           // UI
using UnityEngine.Audio;        // Audio

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicMasterSlider;
    [SerializeField] private Slider musicBGMSlider;
    [SerializeField] private Slider musicSFXSlider;

    private void Awake()
    {
        // ������ �����̴��� ���� ����� �� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);

        // BGM �����̴��� ���� ����� �� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);

        // SFX �����̴��� ���� ����� �� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // �����̴� MinValue 0.001 ���� ������ Log10 ������ �Ǿ��ֱ� ������

    public void SetMasterVolume(float volume)                       // ������ ���� �����̴��� Mixer�� �ݿ��ǰ�
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);    // ������ Log10 ������ 20�� �����ش�
    }
    public void SetBGMVolume(float volume)                          // BGM ���� �����̴��� Mixer�� �ݿ��ǰ�
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)                          // SFX ���� �����̴��� Mixer�� �ݿ��ǰ�
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
