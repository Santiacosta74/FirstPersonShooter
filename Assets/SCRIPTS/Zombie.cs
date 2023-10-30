using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameManager gameManager;
    private Transform player;

    public float speed = 2.0f; 

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player").transform; 

    private void Update()
    {
        Vector3 playerDirection = (player.position - transform.position).normalized;

        transform.Translate(playerDirection * speed * Time.deltaTime);
    }

    void OnDestroy()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            gameManager.ZombieKilled();
        }
    }
}