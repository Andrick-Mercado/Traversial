using System;
using StarterAssets;
using UnityEngine;

public class SimpleKillScript : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private GameObject playerToAttack;
    [SerializeField] 
    private AudioClip PunchAudioClip;
    
    [Header("Settings")]
    [SerializeField]
    private float attackRange;
    [SerializeField] [Range(0f, 5f)]
    private float PunchAudioVolume;
    
        
    private void AttackPlayer(AnimationEvent animationEvent)
    {
        AudioSource.PlayClipAtPoint( PunchAudioClip,transform.position, PunchAudioVolume);
        Vector3 EnemyPos = transform.position;
        Vector3 PlayerPos = playerToAttack.transform.position;

        if ((EnemyPos - PlayerPos).magnitude < attackRange)
        {
            if (playerToAttack.TryGetComponent(out ThirdPersonController playerController))
            {
                playerController.KillPlayer();
            }
        }
    }
}
