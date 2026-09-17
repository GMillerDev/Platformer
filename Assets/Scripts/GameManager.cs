using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private PlayerController player;
    [SerializeField] private HeartsUI heartsUI;

    [Header("Respawn point")]
    [SerializeField] private Transform spawnPoint;

    private const int maxHealth = 6;
    private int currentHealth;

    public bool won { get; private set; }
    public int deaths { get; private set; }

    private void Start()
    {
        currentHealth = maxHealth;
        heartsUI.UpdateHearts(currentHealth);
    }

    public void Win()
    {
        won = true;
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerDied()
    {
        if (won) return;

        deaths++;
        currentHealth = Mathf.Max(currentHealth - 1, 0);
        heartsUI.UpdateHearts(currentHealth);

        if (currentHealth <= 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Vector3? target = spawnPoint != null ? spawnPoint.position : (Vector3?)null;
            player.Respawn(target);
        }
    }
}