using UnityEngine;

public class AnimationSoundEnemyManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private Transform feetTransform;
    [SerializeField] 
    private AudioClip[] FootstepAudioClips;

    [Header("Settings")] 
    [SerializeField] [Range(0f, 5f)]
    private float FootstepAudioVolume;
    
    
    
    
    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(feetTransform.position), FootstepAudioVolume);
            }
        }
    }
}
