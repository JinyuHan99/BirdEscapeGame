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
    public float fadeOutDuration = 5.0f; // 背景音乐淡出的时间，以秒为单位
    public bool isFadingOut = false;

    //public AudioClip gameStartMusic;
    //public AudioClip gameEndMusic;

    void Start()
    {
        // 默认播放介绍音乐
        PlayIntroMusic();
    }

    public void PlayIntroMusic()
    {
        BGMAudioSource.clip = introMusic;
        BGMAudioSource.loop = true; // 让音乐循环
        BGMAudioSource.Play();
    }

    //public void PlayGameStartMusic()
    //{
    //    audioSource.clip = gameStartMusic;
    //    audioSource.loop = true; // 根据需要设置是否循环
    //    audioSource.Play();
    //}

    //public void PlayGameEndMusic()
    //{
    //    audioSource.clip = gameEndMusic;
    //    audioSource.loop = false; // 游戏结束音乐通常不需要循环
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

    // 调用这个函数来开始淡出背景音乐
    public void FadeOutMusic()
    {
        StartCoroutine(FadeOut(BGMAudioSource, fadeOutDuration));
    }

    // 协程实现音乐淡出
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
        audioSource.volume = startVolume; // 如果之后还需要重新播放音乐，重置初始音量
        isFadingOut = false;
    }


}
