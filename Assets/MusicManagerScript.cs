using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{

    public AudioSource BGMAudioSource;
    public AudioSource soundEffectsAudioSource;
    public AudioClip introMusic;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public float fadeOutDuration = 5.0f; // �������ֵ�����ʱ�䣬����Ϊ��λ
    public bool isFadingOut = false;

    //public AudioClip gameStartMusic;
    //public AudioClip gameEndMusic;

    void Start()
    {
        // Ĭ�ϲ��Ž�������
        PlayIntroMusic();
    }

    public void PlayIntroMusic()
    {
        BGMAudioSource.clip = introMusic;
        BGMAudioSource.loop = true; // ������ѭ��
        BGMAudioSource.Play();
    }

    //public void PlayGameStartMusic()
    //{
    //    audioSource.clip = gameStartMusic;
    //    audioSource.loop = true; // ������Ҫ�����Ƿ�ѭ��
    //    audioSource.Play();
    //}

    //public void PlayGameEndMusic()
    //{
    //    audioSource.clip = gameEndMusic;
    //    audioSource.loop = false; // ��Ϸ��������ͨ������Ҫѭ��
    //    audioSource.Play();
    //}

    public void PlayJumpSound()
    {
        soundEffectsAudioSource.clip = jumpSound;
        soundEffectsAudioSource.time = 0.2f;
        soundEffectsAudioSource.loop = false;
        soundEffectsAudioSource.Play();
    }

    public void PlayDeathSound()
    {
        soundEffectsAudioSource.clip = deathSound;
        soundEffectsAudioSource.loop = false;
        soundEffectsAudioSource.time = 0.1f;
        soundEffectsAudioSource.Play();
    }
    public void StopBackgroundMusic()
    {
        BGMAudioSource.Stop();
    }

    // ���������������ʼ������������
    public void FadeOutMusic()
    {
        StartCoroutine(FadeOut(BGMAudioSource, fadeOutDuration));
    }

    // Э��ʵ�����ֵ���
    private IEnumerator FadeOut(AudioSource audioSource, float fadeOutTime)
    {
        isFadingOut = true;
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            //Debug.Log("decreasing volume");
            audioSource.volume -= startVolume * Time.deltaTime / fadeOutTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // ���֮����Ҫ���²������֣����ó�ʼ����
        isFadingOut = false;
    }


}
