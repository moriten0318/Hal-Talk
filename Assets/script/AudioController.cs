using Live2D.Cubism.Framework.MouthMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //音声ファイルの再生とモデルのリップシンクを管理するクラス

    [SerializeField]
    CubismAudioMouthInput audioMouthInput;
    //再生する音声ソースファイルを設定する変数

    public AudioClip AudioClip1;
    public AudioClip AudioClip2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame(毎フレーム更新)
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            // Zが押された時、AudioClip1を再生する
            playAudio(AudioClip1, stopAudio);
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            // Yが押された時、AudioClip2を再生する
            playAudio(AudioClip2, stopAudio);
        }
    }

    public delegate void functionType();
    private IEnumerator Checking(functionType callback)
    {
        if (audioMouthInput?.AudioInput == null)
        {
            Debug.LogError("audioMouthInput.AudioInput no set");
            yield return null;
        }

        while (true)
        {
            // 1フレーム待つ
            yield return new WaitForFixedUpdate();

            if (!audioMouthInput.AudioInput.isPlaying)
            {
                callback();
                break;
            }
        }
    }

    private void playAudio(AudioClip audioClip, functionType callback)
    {
        if (audioMouthInput?.AudioInput == null)
        {
            Debug.LogError("audioMouthInput.AudioInput設定なし");
            return;
        }

        audioMouthInput.AudioInput.clip = audioClip; // 音声ファイルを変更
        audioMouthInput.AudioInput.Play();
        StartCoroutine(Checking(callback));
        Debug.Log("play sound");
    }

    // Checkingメソッドのcallbackメソッドで実行される
    private void stopAudio()
    {
        Debug.Log("stop sound");
    }
}