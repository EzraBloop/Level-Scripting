using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public List<AnimationStateData> animationStates = new List<AnimationStateData>();
    private SpriteRenderer spriteRenderer;
    private Dictionary<PlayerAnimationState, AnimationData> animationDictionary = new Dictionary<PlayerAnimationState, AnimationData>();

    private void Start()
    {
        
    }

    public void InitializeDictionary()
    {

    }
}


[CreateAssetMenu(fileName = "AnimationSO", menuName = "AnimationSO")]
public class AnimationData:ScriptableObject
{
    public string animationName;
    public Sprite[] frames;
    public float frameDelay;

}

public enum PlayerAnimationState
{
    WALK_UP,
    WALK_DOWN,
    WALK_LEFT,
    WALK_RIGHT,
    IDLE_UP,
    IDLE_DOWN,
    IDLE_LEFT,
    IDLE_RIGHT
}

[Serializable]
public class AnimationStateData
{
    public PlayerAnimationState state;
    public AnimationData data;
}
