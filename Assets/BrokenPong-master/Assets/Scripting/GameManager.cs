using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<int> playerScores;
    [SerializeField] private List<TextMeshProUGUI> playerScoreTexts;

    public static GameManager Instance;
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void IncrementScore(PlayerType playerType)
    {
        if (Instance == null) return;
        
        if (Instance.playerScoreTexts.Count <= (int) playerType) return;
        
        Instance.playerScores[(int) playerType]++;
        TextMeshProUGUI scoreText = Instance.playerScoreTexts[(int)playerType];
        scoreText.text = Instance.playerScores[(int)playerType].ToString();
    }

}
