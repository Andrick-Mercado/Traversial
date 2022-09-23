using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogCutscene : MonoBehaviour
{
    [Header("Scriptable")] 
    [SerializeField] private List<CutscenesInfo> cutscenesInfo;

    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private TextBoxBehavior textBoxBehaviorScript;
    [SerializeField] private GameObject textBoxImage;

    [Header("Animation Settings in Seconds")]
    [SerializeField] [Tooltip("Time until text box appears again")] 
    private float textBoxRestingTime;
    [SerializeField] [Tooltip("Time until text begins to be typed")] 
    private float textRestingTime;
    [SerializeField] [Tooltip("Speed of text typing")] 
    private float dialogSpeed;
    
    
    //inner variables
    private int _sentenceCount = 0;
    private int _sceneCount = 0;
    
    public static DialogCutscene Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple DialogCutscene found. Destroying " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartDialogWriter());
    }
    
    private IEnumerator StartDialogWriter()
    {
        yield return new WaitForSeconds(textBoxRestingTime);
        StartCoroutine(DialogWriter());
    }   
    
    private IEnumerator DialogWriter()
    {
        float remainingTime = cutscenesInfo[_sceneCount].Duration;
        
        yield return textBoxBehaviorScript.FadeInOnEnable();
        yield return new WaitForSeconds(textRestingTime);
        remainingTime -= textRestingTime;
        foreach (char letter in cutscenesInfo[_sceneCount].DialogData[_sentenceCount]) 
        {
            textDisplay.text += letter;
            remainingTime -= dialogSpeed;
            yield return new WaitForSeconds(dialogSpeed);
        }

        //arrowContinueGameObject.SetActive(true);
        // yield return new WaitUntil(() => Input.GetMouseButton(0));
        yield return new WaitForSeconds(remainingTime);
        NextSentence();
    }

    private void NextSentence()
    {
        //arrowContinueGameObject.SetActive(false);
        textDisplay.text = "";

        //if we have a scene transition we execute the transition
        if (_sceneCount + 1 >= cutscenesInfo.Count)
        {
            textBoxImage.SetActive(false);
            return;
        }
        
        if (_sentenceCount + 1 >= cutscenesInfo[_sceneCount].DialogData.Count)
        {
            /*MenuManager.Instance.CloseMenu("TextboxMenu");
            textBoxImage.gameObject.SetActive(false);*/
            _sceneCount++;
            _sentenceCount = 0;
            StartCoroutine(DialogWriter());
        }
        else
        {
            //same scene keep inputting text 
            _sentenceCount++;
            StartCoroutine(DialogWriter());
        }

        //use yield return textBoxBehaviorScript.FadeOutOnDisable();
    }
    
    
    [Button("Next Dialog Line")]
    public void NextScene()
    {
        //textBoxImage.gameObject.SetActive(true);
        MenuManager.Instance.OpenMenu("TextboxMenu");
        //arrowContinueGameObject.SetActive(false);
        textDisplay.text = "";
        _sentenceCount = 0;
        _sceneCount++;
        StartCoroutine(DialogWriter());
        

        //SceneTransitionSystem.Instance.TransitionToScene(nextScene);
    }
    
}
