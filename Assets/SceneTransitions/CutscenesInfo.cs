using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CutscenesInfo
{
    [SerializeField] private List<string> dialogs;
    [SerializeField] private float duration;

    public float Duration => duration;
    
    public List<string> DialogData
    {
        get => dialogs;
        private set => dialogs = value;
    }

}
