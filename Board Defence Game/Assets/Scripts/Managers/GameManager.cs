using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    [DefaultExecutionOrder(1000)]
    public class GameManager : MonoBehaviour
    {
        [Inject] private LevelManager levelManager;
        
        private void Start()
        {
            levelManager.InitializeLevel();
        }
    }
}