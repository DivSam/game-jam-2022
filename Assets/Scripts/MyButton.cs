using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{
   public void LoadPreviousScene()
    {
        SceneController.Instance.LoadPreviousScene();
    }
    
    public void LoadNextScene()
    {
        SceneController.Instance.LoadNextScene();
    }

    public void ExitGame()
    {
        GameManager.Instance.SaveAndExit();
    }
}
