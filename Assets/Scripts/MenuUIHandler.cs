using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.GetInstance().TeamColor = color;
    }

    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.GetInstance().TeamColor);
    }

    public void StartNew()
    {
        SceneManager.LoadScene("Main");
    }

    public void Exit()
    {
        MainManager.GetInstance().SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();

#endif

    }

    public void SaveColorClicked()
    {
        MainManager.GetInstance().SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.GetInstance().LoadColor(); 
        ColorPicker.SelectColor(MainManager.GetInstance().TeamColor);
    }
}
