using UnityEngine;
using UnityEngine.UI;

namespace SquareDino.HFC
{
    public class HandView : MonoBehaviour
    {
        private Camera mainCamera;
        private Sprite _handIdleIcon;
        private Sprite _handClickIcon;
        private Image _image;
        private RectTransform _rectTransform;
        
        private void Awake()
        {
            mainCamera = Camera.main;
            _image = gameObject.AddComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
            _image.preserveAspect = true;
        }

        public void Init(Sprite handIdleIcon, Sprite handClickIcon)
        {
            _handIdleIcon = handIdleIcon;
            _handClickIcon = handClickIcon;

            _image.sprite = _handIdleIcon;
            var bounds = _handIdleIcon.bounds;
            _rectTransform.pivot = mainCamera.ScreenToWorldPoint(_handIdleIcon.pivot);
        }
        
        private void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}