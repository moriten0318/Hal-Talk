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

    public void PlayMotion(AnimationClip animation)///このメソッドの引数にAnimationClipを渡せば動くよ
    {
        if ((_motionController == null) || (animation == null))
        {
            return;
        }
        _motionController.PlayAnimation(animation, isLoop: true);
    }
}