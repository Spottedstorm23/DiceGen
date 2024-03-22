using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tutorial
{
    /// <summary>
    /// Closes the Tutorial scene and continues to configurator
    /// </summary>
    public class CloseTutorial : MonoBehaviour
    {
        private Button _close;

        /// <summary>
        /// Adds the listener
        /// </summary>
        private void Start()
        {
            _close = GetComponent<Button>();
            _close.onClick.AddListener(() =>
                SceneChanger.ChangeScene(SceneChanger.Scenes.TutorialScene, SceneChanger.Scenes.ConfiguratorScene));
        }
    }
}