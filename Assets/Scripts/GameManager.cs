using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    public bool won { get; private set; }
    public bool fellOutOfBounds { get; private set; }

    public void Win()
    {
        won = true;
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void FellOutOfBounds()
    {
        fellOutOfBounds = true;
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}
