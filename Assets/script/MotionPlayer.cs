using Live2D.Cubism.Framework.Motion;
using UnityEngine;
public class MotionPlayer : MonoBehaviour
{
    /// <summary>
    /// 動かしたいLive2DモデルにCubismMotionControllerと一緒にアタッチすること！
    /// </summary>
    CubismMotionController _motionController;
    private void Start()
    {
        _motionController = GetComponent<CubismMotionController>();
    }

    public void Play_roopMotion(AnimationClip animation)///このメソッドの引数にAnimationClipを渡せば動くよ
    {
        if ((_motionController == null) || (animation == null))//モーションココントローラーやアニメが未指定ならそのまま返す
        {
            return;
        }
        _motionController.PlayAnimation(animation, isLoop: true);//isloop=trueならループ再生を有効にする
    }

    public void Play_Motion(AnimationClip animation)///引数にAnimationClipを渡せば動くよ
    {
        if ((_motionController == null) || (animation == null))//モーションココントローラーやアニメが未指定ならそのまま返す
        {
            return;
        }
        _motionController.PlayAnimation(animation, isLoop: false);//isloop=falseならループ再生を無効にする
    }
}