using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Dependencies")] [SerializeField]
    private ThirdPersonController playerController;
    
    [Header("Settings")] 
    [SerializeField, Scene]
    private string nextLevelScene;
    [SerializeField, Scene]
    private string tryAgainScene;

    public void StartGame()
    {
        SceneManager.LoadScene(nextLevelScene);
    }

    public void Resume()
    {
        playerController.OnUnlockPlayerMovement();
    }
    
    public void TryAgain()
    {
        SceneManager.LoadScene(tryAgainScene);
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void Back()
    {
        MenuManager.Instance.OpenMenu("MainMenu");
    }
    public void About()
    {
        MenuManager.Instance.OpenMenu("AboutMenu");
    }
}
