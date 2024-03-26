using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Opens the closePanel if necessary. The GameObject needed is said Panel and is set in scene.
/// </summary>
public class OpenEndPanel : MonoBehaviour
{
    public GameObject closePanel;

    /// <summary>
    /// Listens for the Input of an pressed key and checks if its the Escape-Key or on Android the Back one. Then opens the closePanel.
    /// </summary>
    private void Update()
    {
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                closePanel.SetActive(true);
            }
        }
    }
}