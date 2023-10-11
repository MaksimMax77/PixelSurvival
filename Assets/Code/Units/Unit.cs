using System;
using System.Collections.Generic;
using Code.Fsm.Core;
using Code.GOControl;
using Code.Health;
using Code.Inventory.Items.DamageableItems;
using Code.Trigger;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Code.Units
{
    public class Unit: IDisposable
    {
        protected TriggerControl _triggerControl;
        private UnitType[] _enemyTypes;
        private UnitType _unitType;
        private HealthView _healthView;
        private StateMachine _stateMachine;

        public GameObjectsControl GameObjectsControl
        {
            get;
        }
        public Health.Health Health
        {
            get;
            private set;
        }
        public GameObject GameObject
        {
            get;
            private set;
        }
        public List<Unit> Targets
        {
            get;
            private set;
        }
        
        public Unit(GameObjectsControl gameObjectsControl)
        {
            GameObjectsControl = gameObjectsControl;
        }
        
        public virtual void Install(UnitConfiguration unitConfiguration)
        {
            InstantiateGameObject(unitConfiguration.UnitObject);
            _unitType = unitConfiguration.UnitType;
            _enemyTypes = unitConfiguration.EnemyTypes;
            _stateMachine = new StateMachine(unitConfiguration.RootAction);
            _stateMachine.Blackboard.AddData(nameof(Unit), this);
            Targets = new List<Unit>();
            Health = new Health.Health(unitConfiguration.MaxHealth);
            _healthView = GameObject.GetComponent<HealthView>();
            _triggerControl = GameObject.GetComponent<TriggerControl>();
            _triggerControl.DamageableItemTrigger += OnDamageableItemTrigger;
            Health.CurrentHealth.OnChange += OnHealthUpdate;
            _healthView.InitTimer();
        }
        
        public void Update()
        {
            _stateMachine.Update();
            _healthView.ViewUpdate();
        }
        
        public void Enable()
        {
            _stateMachine.Restart();
            _healthView.HealthBarDisable();
            GameObjectsControl.SetActive(ObjectType.Unit, GameObject, true);
        }

        public void Disable()
        {
            GameObjectsControl.SetActive(ObjectType.Unit, GameObject, false);
            _healthView.HealthBarDisable();
        }

        public void BlackboardAddData(string key, object data)
        {
            _stateMachine.Blackboard.AddData(key, data);
        }
        public virtual void Dispose()
        {
            _triggerControl.DamageableItemTrigger -= OnDamageableItemTrigger;
            Health.CurrentHealth.OnChange -= OnHealthUpdate;
        }

        public void AddTarget(Unit unit)
        {
            for (int i = 0, len = _enemyTypes.Length; i< len; ++i)
            {
                if (_enemyTypes[i] != unit._unitType)
                {
                    continue;
                }
                Targets.Add(unit);
                return;
            }
        }
        
        private void OnDamageableItemTrigger(DamageableItem damageableItem)
        {
            Health.HealthRemove(damageableItem.Damage);
            Object.Destroy(damageableItem.gameObject);
        }

        private void OnHealthUpdate(float oldValue, float newValue)
        {
            _healthView.OnHealthUpdate(newValue / Health.MaxHealth);
        }

        private void InstantiateGameObject(GameObject prefab)
        {
            GameObject = GameObjectsControl.GoInstantiate(ObjectType.Unit, prefab);
        }

        public class Factory : PlaceholderFactory<Unit>
        {
        }
    }
}
