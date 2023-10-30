using UnityEngine;
using UnityEngine.UI;

public class WinCanvasManager : MonoBehaviour
{
    public GameObject winCanvas;
    public int enemiesToWin = 10; 
    public Text winText; 

    private int enemiesKilled = 0;

    private void Start()
    {
        winCanvas.SetActive(false); 
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled >= enemiesToWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winCanvas.SetActive(true);
        winText.text = "Has terminado con todos los zombies!"; 
    }
}