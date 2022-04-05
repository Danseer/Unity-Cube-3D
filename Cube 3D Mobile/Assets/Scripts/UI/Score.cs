using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _score;

    public static int intScore=0;

    void Awake()
    {
        Collisions.AddScoreEvent.AddListener(UpdateScore);
    }

    private void UpdateScore()
    {
        _score.text = intScore.ToString();
    }
}
