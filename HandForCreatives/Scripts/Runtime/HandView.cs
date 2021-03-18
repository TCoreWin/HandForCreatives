using UnityEngine;
using UnityEngine.UI;

namespace SquareDino.HFC
{
    public class HandView : MonoBehaviour
    {
        private Sprite _handIdleIcon;
        private Sprite _handClickIcon;
        
        private Image _image;
        private RectTransform _rectTransform;
        
        private void Awake()
        {
            _image = gameObject.AddComponent<Image>();
            _image.preserveAspect = true;
            _image.raycastTarget = false;
            
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.pivot = new Vector2(0.3f, .85f);
        }

        public void Init(Sprite handIdleIcon, Sprite handClickIcon, Color color, float sizeMultiply)
        {
            _handIdleIcon = handIdleIcon;
            _handClickIcon = handClickIcon;
            _image.color = color;
            _rectTransform.sizeDelta *= sizeMultiply;
            
            ChangeSprite(_handIdleIcon);
        }

        private void ChangeSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
        
        private void Update()
        {
            transform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
                ChangeSprite(_handClickIcon);
            
            if (Input.GetMouseButtonUp(0))
                ChangeSprite(_handIdleIcon);
        }
    }
}