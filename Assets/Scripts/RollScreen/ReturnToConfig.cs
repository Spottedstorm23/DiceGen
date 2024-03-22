using UnityEngine;
using UnityEngine.UI;

namespace RollScreen
{
    /// <summary>
    /// Return to the configurator scene
    /// </summary>
    public class ReturnToConfig : MonoBehaviour
    {
        private Button _newConfigButton;

        /// <summary>
        /// Set the clickListener and call to the <see cref="SceneChanger"/>
        /// </summary>
        private void Start()
        {
            _newConfigButton = GetComponent<Button>();
            _newConfigButton.onClick.AddListener(() =>
                SceneChanger.ChangeScene(SceneChanger.Scenes.RollScreenScene, SceneChanger.Scenes.ConfiguratorScene));
        }
    }
}