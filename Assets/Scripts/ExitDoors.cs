using TMPro;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ExitGate : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private TMP_Text GoalText;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private int requiredPoints = 4;
    private SpriteRenderer gateRenderer;
    private bool won;

    private void Awake()
    {
        gateRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        WinPanel.SetActive(false);
    }

    private void Update()
    {
        if (won) return;
        bool ready = player.GetPoints() >= requiredPoints;
        gateRenderer.color = ready ? Color.green : Color.red;
        GoalText.text = ready
            ? "Wyjscie otwarte - dotknij bramki!"
            : "Zbierz " + requiredPoints + " pkt";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (won) return;
        PlayerMovement visitor =
            other.GetComponentInParent<PlayerMovement>();
        if (visitor != player) return;
        if (player.GetPoints() < requiredPoints) return;

        won = true;
        GoalText.text = "Poziom ukonczony!";
        WinPanel.SetActive(true);
        player.enabled = false;
        Rigidbody2D body = player.GetComponent<Rigidbody2D>();
        body.linearVelocity = Vector2.zero;
        body.simulated = false;
    }
}