using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int zombiesToKill = 1;
    public int zombiesKilled = 0;
    public Text zombiesKilledText;
    public Canvas CanvasWin; 
    public Canvas CanvasLose; 

    public void ZombieKilled()
    {
        zombiesKilled++;

        zombiesKilledText.text = "Zombies Eliminados: " + zombiesKilled;

        if (zombiesKilled >= zombiesToKill)
        {
            WinGame();
        }
    }

    public void PlayerDefeated()
    {
        ShowDefeatCanvas();
    }

    void WinGame()
    {
        CanvasWin.enabled = true;
    }

    void ShowDefeatCanvas()
    {
        CanvasLose.enabled = true; 
    }
}