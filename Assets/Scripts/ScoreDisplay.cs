using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        if (player == null)
        {
            player = FindFirstObjectByType<PlayerMovement>();
        }

        if (scoreText == null)
        {
            scoreText = GetComponentInChildren<TMP_Text>();
        }
    }

    private void Update()
    {
        if (player == null || scoreText == null) return;

        scoreText.text = "Punkty: " + player.GetPoints();
    }
}