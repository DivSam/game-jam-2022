using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private TextMeshProUGUI text;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerController>();
        Debug.Log(text.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            text.text = Mathf.Round(player.getCurrentDistanceFromSpawn()).ToString();
        }
    }
}
