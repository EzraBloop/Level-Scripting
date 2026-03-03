using UnityEngine;

public class PlayerAnimationSO : MonoBehaviour
{
    [CreateAssetMenu(fileName = "AnimationSO", menuName = "AnimationSO")]
    public class AnimationData : ScriptableObject
    {
        public string animationName;
        public Sprite[] frames;
        public float frameDelay;
    }
}
