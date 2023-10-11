using Code.Core.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Health
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private float _time;
        [SerializeField] private Image _healthValueImage;
        [SerializeField] private GameObject _healthBar; 
        private Timer _timer;
        public void InitTimer()
        {
            _timer = new Timer(_time);
        }
        public void OnHealthUpdate(float health)
        {
            _healthBar.gameObject.SetActive(true);
            _healthValueImage.fillAmount = health;
        }
        public void ViewUpdate()
        {
            if (_healthBar == null)
            {
                return;
            }

            if (!_healthBar.gameObject.activeSelf)
            {
                return;
            }
            
            DisableHealthBarByTimer();
        }
        public void HealthBarDisable()
        {
            _healthBar.gameObject.SetActive(false);
        }
        private void DisableHealthBarByTimer()
        {
            _timer.UpdateTimer();
            if (!_timer.available)
            {
                return;
            }

            _timer.TimerZero();
            _healthBar.gameObject.SetActive(false);
        }
    }
}
