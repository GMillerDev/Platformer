using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Win();
        }
    }
}
