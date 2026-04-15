using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI nowScoreUI;
    public int nowScore;
    public TextMeshProUGUI bestScoreUI;
    public int bestScore;


    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        
        nowScore = 0;
        
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        
        nowScoreUI.text = "Now Score : " + nowScore;
        bestScoreUI.text = "Best Score : " + bestScore;
    }
}
