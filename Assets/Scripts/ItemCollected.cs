
using System;
using UnityEngine;

public class ItemCollected : MonoBehaviour
{
    [Header("Dependencies")] [SerializeField]
    private GameObject objectToCollect;
    [SerializeField] 
    private AudioClip CollectedAudioClip;

    [Header("Settings")] 
    [SerializeField] [Range(0f, 5f)]
    private float CollectedAudioVolume;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ExitLevelManager.Instance.hasCollected)
        {
            (objectToCollect).SetActive(false);
            AudioSource.PlayClipAtPoint(CollectedAudioClip, transform.position, CollectedAudioVolume);
            ExitLevelManager.Instance.hasCollected = true;
        }
    }
}
