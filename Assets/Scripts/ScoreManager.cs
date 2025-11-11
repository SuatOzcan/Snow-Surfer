using System.Text;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    int _score = 0;
    
    public void AddScore(int additionalScore)
    {
        _score += additionalScore;
        _scoreText.text = "Score: " + _score.ToString();
    }
}
