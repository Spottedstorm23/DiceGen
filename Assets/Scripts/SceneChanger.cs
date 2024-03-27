using UnityEngine;

/// <summary>
/// Changes the scene and deytroys the Dicemanager if necessary
/// </summary>
public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// Enum that stores all possible scenes
    /// </summary>
    public enum Scenes
    {
        TutorialScene,
        ConfiguratorScene,
        RollScreenScene
    }

    /// <summary>
    /// Changes the scene. If the current scene is not the configurator scene the diceManager is destroyed to prevent errors.
    /// </summary>
    /// <param name="current"><see cref="Scenes"/> that describes the current scene</param>
    /// <param name="changeTo"><see cref="Scenes"/> that describes the targeted scene</param>
    public static void ChangeScene(Scenes current, Scenes changeTo)
    {
        if (current != Scenes.ConfiguratorScene)
        {
            Destroy(DiceManager.Manager.gameObject);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(changeTo.ToString());
    }
}