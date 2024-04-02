using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RollScreen
{
    /// <summary>
    /// Activates or deactivates the visual statistics on a togglechange
    /// </summary>
    public class StatisticToggle : MonoBehaviour
    {
        [SerializeField] private GameObject stats;
        [SerializeField] private Toggle showStats;

        private void Start()
        {
            showStats.onValueChanged.AddListener((bool tmpBool) =>
            {
                if (!stats.activeInHierarchy && !showStats.isOn)
                {
                    return;
                }

                stats.SetActive(!stats.activeInHierarchy);
            });
        }
    }
}