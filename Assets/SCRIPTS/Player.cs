using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Text Life;
    public GameManager gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameManager != null)
        {
            gameManager.PlayerDefeated();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void UpdateHealthUI()
    {
        if (Life != null)
        {
            Life.text = "Vida: " + currentHealth;
        }
    }
}