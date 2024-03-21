using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToConfig : MonoBehaviour
{
    private Button _newConfigButton;
    
    // Start is called before the first frame update
    void Start()
    {
        _newConfigButton = GetComponent<Button>();
        _newConfigButton.onClick.AddListener(ReturnToConf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnToConf()
    {
        SceneManager.LoadScene("ConfiguratorScene");
        Destroy(DiceManager.manager.gameObject);
    }
}
