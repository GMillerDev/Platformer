using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private PlayerController player;
    [SerializeField] private HeartsUI heartsUI;

    private const int maxHealth = 6;
    private int currentHealth;

    public bool won { get; private set; }

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
        currentHealth = Mathf.Max(currentHealth - 1, 0);
        heartsUI.UpdateHearts(currentHealth);

        if (currentHealth <= 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            player.Respawn();
        }
    }
}
