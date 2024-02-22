using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    [DefaultExecutionOrder(1000)]
    public class GameManager : MonoBehaviour
    {
        [Min(1)][SerializeField] private int level = 1;
        [Inject] private LevelManager levelManager;
        private void Start()
        {
            levelManager.InitializeLevel(level);
        }
    }
}