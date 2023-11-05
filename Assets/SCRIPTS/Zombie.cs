using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameManager gameManager;
    private Transform player;

    public float speed = 2.0f;
    public int damage = 20; 

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 playerDirection = (player.position - transform.position).normalized;
        transform.Translate(playerDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
        }
    }

    void OnDestroy()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            gameManager.ZombieKilled();
        }
    }
}