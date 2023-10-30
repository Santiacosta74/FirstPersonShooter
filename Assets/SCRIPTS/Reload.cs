using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Text reloadMessageText;

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ShowReloadMessage(false);
        }
    }

    public void ShowReloadMessage(bool show)
    {
        reloadMessageText.gameObject.SetActive(show);
    }
}
