using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BestScoreText : MonoBehaviour
{
    TextMeshProUGUI currText;
    // Start is called before the first frame update
    void Start()
    {
        currText = GetComponent<TextMeshProUGUI>();
        currText.text = "High Score: " + ((int)GameManager.Instance.BestScore).ToString();
    }

}
