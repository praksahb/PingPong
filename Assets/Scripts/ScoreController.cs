using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private Player pType;

    private int score = 0;

    private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();

        score = GameManager.Instance.TrackScore(pType);
    }

    private void FixedUpdate()
    {
        score = GameManager.Instance.TrackScore(pType);
        UpdateScore();
    }

    public void IncrementScore()
    {
        score = GameManager.Instance.TrackScore(pType);
        UpdateScore();

        //if(score >= 5)
        //{
        //    GameManager.Instance.GameWon(pType);
        //}
    }

    private void UpdateScore()
    {
        scoreText.SetText("Score: {0}", score);
    }
}
