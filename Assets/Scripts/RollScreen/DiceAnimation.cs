using UnityEngine;
using UnityEngine.UI;

namespace RollScreen
{
    /// <summary>
    /// Class responsible for the rolling animation of the dices. 
    /// </summary>
    /// <param name="diceAnimationGameObjects">An array of GameObjects set in the scene, where the dices may spawn.</param>
    /// <param name="colorMaterials">All possible materials a dice can have. Set in scene. The order of these must be the same as in <see cref="DiceColors"/></param>
    /// <param name="typeMeshes">All meshes for the types. Set in scene. The order of these must be the same as in <see cref="DiceTypes"/></param>
    public class DiceAnimation : MonoBehaviour
    {
        private Button _roll;
        private DiceManager _diceManager;

        public GameObject[] diceAnimationGameObjects;
        public GameObject[] instancedDices = new GameObject[10];
        public Material[] colorMaterials;
        public Mesh[] typeMeshes;


        /// <summary>
        /// Add the click-listener and the diceManager
        /// </summary>
        private void Start()
        {
            _roll = GetComponent<Button>();
            _roll.onClick.AddListener(StartAnimation);

            _diceManager = DiceManager.Manager;
        }

        /// <summary>
        /// For each Dice that is set, any existing object is destroyed and a new one is created.
        /// Only when the dice is not set to lock the results. 
        /// </summary>
        private void StartAnimation()
        {
            for (var i = 0; i < _diceManager.diceCounter; i++)
            {
                if (_diceManager.AllDice[i].LockResult) continue;
                ResetObject(i);
                CreateDiceObject(i);
            }
        }

        /// <summary>
        /// Creates an instanced object of one of the ten placeholders in the scene.
        /// </summary>
        /// <decsription>
        /// The GameObject in <c>diceAnimationGameObjects</c> at key i is instanced and stored into instancedDices at the same key.
        /// Afterwards the mesh corresponding to the type is assigned and a mesh collider added.
        /// The collider is not on the PlaceHolderObject as it seemed to not really have the option to set the mesh via script.
        /// The instanced object is assigned a material as well as a random rotation,
        /// that creates different starting positions and thus randomized the falling a bit more.
        /// The finished object is then activated.
        /// </decsription>
        /// <param name="i">Number of the dice and therefore key of the diceObjects</param>
        private void CreateDiceObject(int i)
        {
            var tempType = _diceManager.AllDice[i].Type;
            var tempColor = _diceManager.AllDice[i].Color;

            instancedDices[i] = Instantiate(diceAnimationGameObjects[i]);

            instancedDices[i].GetComponent<MeshFilter>().mesh = typeMeshes[(int)tempType];

            instancedDices[i].AddComponent<MeshCollider>();
            instancedDices[i].GetComponent<MeshCollider>().convex = true;

            instancedDices[i].GetComponent<Renderer>().material = colorMaterials[(int)tempColor];

            instancedDices[i].transform.Rotate(Random.Range(0, 46), Random.Range(0, 46), Random.Range(0, 46));
            ScaleDependingOnType(tempType, i);

            instancedDices[i].SetActive(true);
        }

        /// <summary>
        /// Destroy the GameObject if it exists
        /// </summary>
        /// <param name="i">Key of the current dice</param>
        private void ResetObject(int i)
        {
            if (instancedDices[i] != null)
            {
                Destroy(instancedDices[i]);
            }
        }

        /// <summary>
        /// The meshes of the D2, D12 and D4 are smaller or bigger than the others.
        /// Due to that the GameObjects need to be scaled separately
        /// </summary>
        /// <param name="tempType">The type of the dice that needs to be checked</param>
        /// <param name="i">The key of the current dice, so it can be scaled</param>
        private void ScaleDependingOnType(DiceTypes tempType, int i)
        {
            instancedDices[i].transform.localScale = tempType switch
            {
                DiceTypes.D12 => new Vector3(0.9f, 0.9f, 0.9f),
                DiceTypes.D2 => new Vector3(2f, 0.1f, 2f),
                DiceTypes.D4 => new Vector3(2f, 2f, 2f),
                _ => instancedDices[i].transform.localScale
            };
        }
    }
}