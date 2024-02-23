using System;
using BoardDefenceGame.MVP.Interface.Unit;
using BoardDefenceGame.MVP.Model;
using UnityEngine;

namespace BoardDefenceGame.MVP.Presenter
{
    public class EnemyUnitPresenter : MonoBehaviour, IUnitPresenter
    {
        [SerializeField] private EnemyUnitModel model;
        [SerializeField] private EnemyUnitView view;
        public IUnitModel Model => model;
        public Action<EnemyUnitPresenter> OnEnemyUnitDead { get; set; }

        private void Awake()
        {
            view.SetUnitTransform(transform);
            model.CurrentHealth.Value = model.Health;
        }

        private void OnEnable()
        {
            model.Position.OnValueChanged += OnPositionChanged;
            model.CurrentHealth.OnValueChanged += OnCurrentHealthChanged;
        }

        private void OnDisable()
        {
            model.Position.OnValueChanged -= OnPositionChanged;
            model.CurrentHealth.OnValueChanged -= OnCurrentHealthChanged;
        }

        private void OnCurrentHealthChanged(float currentHealth)
        {
            model.CurrentHealth.Value = currentHealth;
            view.SetHealthBar(model.CurrentHealth.Value / model.Health);
            if (model.CurrentHealth.Value  <= 0)
            {
                OnEnemyUnitDead?.Invoke(this);
                view.DestroyUnit();
            }
        }
        
        public void OnPositionChanged(Vector3 position)
        {
            view.SetUnitPosition(position);
        }

        public void SetPosition(Vector3 position)
        {
            model.Position.Value = position;
        }

        public void SetIndex(int lineIndex, int tileIndex)
        {
            model.LineIndex = lineIndex;
            model.TileIndex = tileIndex;    
        }

        public int GetLineIndex()
        {
            return model.LineIndex;
        }

        public int GetTileIndex()
        {
            return model.TileIndex;
        }
        
        public float GetMovementSpeed()
        {
            return model.Speed;
        }
        
        public void TakeDamage(float damage)
        {
            model.CurrentHealth.Value -= damage;
        }

    }
}