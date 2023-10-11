using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Inventory
{
    public class CellView : MonoBehaviour
    {
        public event Action<int> DestroyClicked;
        [SerializeField] private int _index;
        [SerializeField] private Button _itemImage;
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private GameObject _amountTextGameObject;
        [SerializeField] private Button _destroyButton;
        private bool _itemImageClicked;

        private void Awake()
        {
            _destroyButton.onClick.AddListener(OnDestroyClick);
            _itemImage.onClick.AddListener(OnItemImageClick);
        }

        public void OnAddItem(Sprite sprite, int amount)
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.image.sprite = sprite;
            _amountText.text = amount.ToString();
            if (amount <= 0)
            {
                _amountTextGameObject.SetActive(false);
                return;
            }
            _amountTextGameObject.SetActive(true);
        }

        public void OnRemoveItem()
        {
            _itemImage.gameObject.SetActive(false);
        }
        
        private void OnDestroyClick()
        {    
            _destroyButton.gameObject.SetActive(false);
            DestroyClicked?.Invoke(_index);
        }

        private void OnItemImageClick()
        {
            _destroyButton.gameObject.SetActive(!_itemImageClicked);
            _itemImageClicked = !_itemImageClicked;
        }

        private void OnDestroy()
        {
            _destroyButton.onClick.RemoveListener(OnDestroyClick);
        }
    }
}
