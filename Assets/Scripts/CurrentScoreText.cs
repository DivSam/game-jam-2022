using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrentScoreText : MonoBehaviour
{
    TextMeshProUGUI currText;
    // Start is called before the first frame update
    void Start()
    {
        currText = GetComponent<TextMeshProUGUI>();
        currText.text = "Previous Score: " + ((int)GameManager.Instance.CurrentScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
