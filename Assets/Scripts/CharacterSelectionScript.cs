using UnityEngine;

public class CharacterSelectionScript : MonoBehaviour
{
    [SerializeField]
    GameObject _scoreCanvas;
    [SerializeField]
    GameObject _dinoSprite;
    [SerializeField]
    GameObject _frogSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    void BeginGame()
    {
        Time.timeScale = 1.0f;
        _scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SelectDino()
    {
        _dinoSprite.SetActive(true);
        BeginGame();
    }

    public void SelectKamil()
    {
        _frogSprite.SetActive(true);
        BeginGame();
    }
}
