using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnDestroy()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            gameManager.ZombieKilled();
        }
    }

}