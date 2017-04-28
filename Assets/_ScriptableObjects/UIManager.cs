using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Managers/UIManager")]
public class UIManager : ScriptableObject {


    private bool _isday = true;
    public bool IsDay { get { return _isday; } 
        set
        {
            _isday = value;

            if (_isday)
                sun.SetActive(true);
            else
                sun.SetActive(false);
        }
    }

    private GameObject sun;

    private void OnEnable()
    {
        sun = GameObject.FindWithTag("Sun");
    }

    public void ToggleDayNight()
    {
        IsDay = !IsDay;
    }

}
