using UnityEngine; 
    
    public class OutOfBoundsTrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {
                gameManager.PlayerDied();
            }
    }
}
