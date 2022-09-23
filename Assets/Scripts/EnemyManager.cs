using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Dependencies")] [SerializeField]
    private GameObject[] enemyGameObjects;
    
    public static EnemyManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple EnemyManager found. Destroying " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ActivateEnemies()
    {
        foreach (var enemy in enemyGameObjects)
        {
            enemy.SetActive(true);
        }
    }
}
