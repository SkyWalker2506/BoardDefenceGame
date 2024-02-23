using BoardDefenceGame.MVP.Interface.Unit;
using UnityEngine;
using UnityEngine.UI;

namespace BoardDefenceGame.MVP.Presenter
{
    public class EnemyUnitView : MonoBehaviour, IUnitView
    {
        public Transform UnitTransform { get;private set;}
        [SerializeField] private Image healthImage; 
        public void SetUnitTransform(Transform tr)
        {
            UnitTransform = tr;
        }
        public void SetUnitPosition(Vector3 position)
        {
            UnitTransform.position = position;
        }

        public void DestroyUnit()
        {
            Destroy(UnitTransform.gameObject);
        }
        
        public void SetHealthBar(float fillAmount)
        {
            healthImage.fillAmount = fillAmount;
        }
    }
}