using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private float bestScore = 0;
    private float currentScore = 0;

    public Vector3 playerPos;

    //public Vector3 PlayerPosition
    //{
   //     get { return playerPos; }
    //    set { playerPos = value; }
   // }
    public float CurrentScore
    {
        get { return currentScore; }
    }
    public float BestScore
    {
        get { return bestScore; }
    }
    public static GameManager Instance
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
    public void SaveScore(float score)
    {
        currentScore = score;
        if (score > bestScore) bestScore = score;
    }

}
