using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Opens a help panel where the explanation for the current screen is given again
/// </summary>
public partial class OpenHelp : MonoBehaviour
{
    [SerializeField] private Button help;
    [SerializeField] private Text helpText;
    [SerializeField] private GameObject helpPanel;

    // Start is called before the first frame update
    private void Start()
    {
        help.onClick.AddListener(() =>
        {
            helpPanel.SetActive(!helpPanel.activeInHierarchy);
            helpText.text = helpPanel.activeInHierarchy ? "X" : "?";
        });
    }
}