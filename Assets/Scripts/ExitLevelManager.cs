using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class ExitLevelManager : MonoBehaviour
{
    [Header("Settings")] [SerializeField, Scene]
    private string sceneToLoad;
    
    public bool hasCollected;

    public static ExitLevelManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple ExitLevelManager found. Destroying " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasCollected)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
