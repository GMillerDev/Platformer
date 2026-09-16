using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    [Header("Respawn")]
    [SerializeField] private Rigidbody2D player;
    [Tooltip("Where the player respawns. If left empty, the player's starting position is used.")]
    [SerializeField] private Transform spawnPoint;

    public bool won { get; private set; }
    public bool fellOutOfBounds { get; private set; }
    public int deaths { get; private set; }

    private Vector3 startPosition;

    private void Start()
    {
        if (player != null)
        {
            startPosition = player.transform.position;
        }
    }

    public void Win()
    {
        won = true;
        winScreen.SetActive(true);
    }

    public void FellOutOfBounds()
    {
        if (won) return;

        fellOutOfBounds = true;
        deaths++;
        Respawn();
    }

    private void Respawn()
    {
        if (player == null) return;

        Vector3 target = spawnPoint != null ? spawnPoint.position : startPosition;

        player.linearVelocity = Vector2.zero;
        player.position = target;
        player.transform.position = target;

        fellOutOfBounds = false;
    }
}