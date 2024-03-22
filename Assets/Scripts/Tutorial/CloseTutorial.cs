using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseTutorial : MonoBehaviour
{
    private Button _close;

    // Start is called before the first frame update
    void Start()
    {
        _close = GetComponent<Button>();
        _close.onClick.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("ConfiguratorScene");
    }
}
