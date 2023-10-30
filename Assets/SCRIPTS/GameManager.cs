using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int zombiesToKill = 10;  
    public int zombiesKilled = 0;   

    public Text zombiesKilledText;   

    public void ZombieKilled()
    {
        zombiesKilled++;

        // Actualiza el texto que muestra la cantidad de zombies eliminados.
        zombiesKilledText.text = "Zombies Eliminados: " + zombiesKilled;

        // Verifica si se han eliminado suficientes zombies para ganar.
        if (zombiesKilled >= zombiesToKill)
        {
            WinGame();  // Llama a una función que maneja la victoria.
        }
    }

    void WinGame()
    {
        // Aquí puedes agregar las acciones que deseas realizar cuando el jugador gane, como cargar una escena de victoria.
        SceneManager.LoadScene("VictoryScene");
    }
}