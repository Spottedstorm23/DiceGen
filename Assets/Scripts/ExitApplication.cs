using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Exit the Application from the endPanel
/// </summary>
/// <param name="yes">The Button upon which the application ends</param>
/// <param name="no">Button that resumes the application</param>
/// <param name="panel">Panel where the buttons are located</param>
public class ExitApplication : MonoBehaviour
{
    [SerializeField] private Button yes;
    [SerializeField] private Button no;

    [SerializeField] private GameObject panel;

    /// <summary>
    /// Add the eventListner
    /// </summary>
    private void Start()
    {
        yes.onClick.AddListener(Exit);
        no.onClick.AddListener(ClosePanel);
    }

    /// <summary>
    /// Exits the Application, if ever build for IOS see Unity manual as this function causes problems there
    /// </summary>
    private void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Deactivate the closePanel
    /// </summary>
    private void ClosePanel()
    {
        panel.SetActive(false);
    }
}