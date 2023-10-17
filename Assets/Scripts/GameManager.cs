using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public int score;

    void Update() 
    {
        scoreText.text = score.ToString();    
    }

}
