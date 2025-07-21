
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LuckGame {
    public class Card : CardBase , IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
    {
        private Canvas canvas;  // 卡牌所在的Canvas
        private RectTransform   rectTransform; // 卡牌的RectTransform
        private Image cardImage; // 卡牌的Image
        private CardInfo cardInfo; // 卡牌信息
        // 卡牌 状态
        [Header("卡牌状态")]
        public bool isSelected; // 是否选中
        public bool isDragging; // 是否拖动
        public bool wasDragging; // 是否拖动过 

        [Header("卡牌视觉")]
        [HideInInspector] public CardVisual cardVisual;
        [SerializeField] private GameObject cardVisualPrefab;
        [Header("拖动速度")]
        [SerializeField] private float moveSpeedLimit = 50;

        [Header("选中效果")]
        public bool selected; 
        public float selectionOffset = 50;
        private float pointerDownTime; 
        private float pointerUpTime;
        public bool isHovering;
        //Visual是否启用
        private bool isInastantiateVisual = true;
        private VisualCardsHandler visualHandler;
        // 偏移量
        private Vector3 offset;


        private void Start()
        {
            canvas = GetComponentInParent<Canvas>();
            cardImage = GetComponent<Image>();

            if (!isInastantiateVisual)
                return;
            visualHandler = FindObjectOfType<VisualCardsHandler>();
            cardVisual = Instantiate(cardVisualPrefab, visualHandler ? visualHandler.transform : canvas.transform).GetComponent<CardVisual>();
            cardVisual.Initialize(this);
        }
        void Update()
        {
            ClampPosition();

            if (isDragging)
            {

                Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
                Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
                Vector2 velocity = direction * Mathf.Min(moveSpeedLimit, Vector2.Distance(transform.position, targetPosition) / Time.deltaTime);

                transform.Translate(velocity * Time.deltaTime);
            }
        }

        void ClampPosition()
        {
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x, screenBounds.x);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -screenBounds.y, screenBounds.y);
            transform.position = new Vector3(clampedPosition.x, clampedPosition.y, 0);
        }

    

        public void OnBeginDrag(PointerEventData eventData)
        {

            EventCenterManager.Instance.TriggerEvent<Card>(CardEvent.BeginDrag,this);
            Vector2 mousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = mousPosition - (Vector2)rectTransform.position;
            isDragging = true;
            canvas.GetComponent<GraphicRaycaster>().enabled = false;
            cardImage.raycastTarget = false;

            wasDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            EventCenterManager.Instance.TriggerEvent<Card>(CardEvent.EndDrag, this);
            isDragging = false;
            canvas.GetComponent<GraphicRaycaster>().enabled = true;
            cardImage.raycastTarget = true;
            
            MonoManager.Instance.StartCoroutine(FrameWait());
            IEnumerable FrameWait()
            {
                yield return new WaitForEndOfFrame();
                wasDragging = false;
            }
            wasDragging = false;
        
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        internal int ParentIndex()
        {
            throw new NotImplementedException();
        }

        internal float SiblingAmount()
        {
            throw new NotImplementedException();
        }
    }
}