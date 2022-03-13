using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private static SceneController instance = null;
    public static SceneController Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.root);
    }
    public void ReloadCurrentScene()
    {
        Debug.Log("Reloading");
        int idx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(idx);
    }

    public void LoadNextScene()
    {
        Debug.Log("Failure");
        int idx = SceneManager.GetActiveScene().buildIndex;
        Debug.Log((idx + 1) % (SceneManager.sceneCount + 1));
        SceneManager.LoadScene((idx + 1) % (SceneManager.sceneCount + 1));
    }

    public void LoadPreviousScene()
    {
        int idx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((idx - 1) );
    }
}
