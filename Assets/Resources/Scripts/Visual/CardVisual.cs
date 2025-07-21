using System;
using Unity.VisualScripting;
using UnityEngine;

namespace LuckGame
{
    public class CardVisual : MonoBehaviour
    {
        private bool initalize = false;

        [Header("卡牌组件")]
        public  Card parentCard;
        private int savedIndex;
        [SerializeField] private Transform tiltParent;

        private Transform cardTransform;

        [Header("卡牌倾斜")]
        private float manualTiltAmount = 20f;
        [SerializeField] private float autoTiltAmount = 30;
        [SerializeField] private float tiltSpeed = 20;


        private float curveRotationOffset;
        private Canvas canvas;
        [Header("Curve")]
        [SerializeField] private CurveParameters curve;

        internal void Initialize(Card card, int index = 0)
        {

            parentCard = card;
            cardTransform = card.transform;
            canvas = GetComponent<Canvas>();
            EventCenterManager.Instance.AddEventListener<Card>(CardEvent.PointerEnter, PointerEnter);
            EventCenterManager.Instance.AddEventListener<Card>(CardEvent.PointerExit, PointerExit);
            EventCenterManager.Instance.AddEventListener<Card>(CardEvent.BeginDrag, BeginDrag);
            EventCenterManager.Instance.AddEventListener<Card>(CardEvent.EndDrag, EndDrag);
            EventCenterManager.Instance.AddEventListener<Card>(CardEvent.PointerDown, PointerDown);
            EventCenterManager.Instance.AddEventListener<Card>(CardEvent.PointerUp, PointerUp);
            EventCenterManager.Instance.AddEventListener<Card>(CardEvent.Select, Select);


            initalize = true;

        }

        private void Update()
        {
            if (!initalize || parentCard == null) return;
            HandPositioning();
            SmoothFollow();
            FollowRotation();
            CardTilt();


        }
        //卡牌倾斜方法
        private void CardTilt()
        {
            savedIndex = parentCard.isDragging ? savedIndex : parentCard.ParentIndex();
            float sine = Mathf.Sin(Time.time + savedIndex) * (parentCard.isHovering ? .2f : 1);
            float cosine = Mathf.Cos(Time.time + savedIndex) * (parentCard.isHovering ? .2f : 1);

            Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float tiltX = parentCard.isHovering ? ((offset.y * -1) * manualTiltAmount) : 0;
            float tiltY = parentCard.isHovering ? ((offset.x) * manualTiltAmount) : 0;
            float tiltZ = parentCard.isDragging ? tiltParent.eulerAngles.z : (curveRotationOffset * (curve.rotationInfluence * parentCard.SiblingAmount()));

            float lerpX = Mathf.LerpAngle(tiltParent.eulerAngles.x, tiltX + (sine * autoTiltAmount), tiltSpeed * Time.deltaTime);
            float lerpY = Mathf.LerpAngle(tiltParent.eulerAngles.y, tiltY + (cosine * autoTiltAmount), tiltSpeed * Time.deltaTime);
            float lerpZ = Mathf.LerpAngle(tiltParent.eulerAngles.z, tiltZ, tiltSpeed / 2 * Time.deltaTime);

            tiltParent.eulerAngles = new Vector3(lerpX, lerpY, lerpZ);
        }

        //跟随旋转方法
        private void FollowRotation()
        {
            if(parentCard.isDragging) return;
            transform.rotation = Quaternion.Euler(0, 0, parentCard.transform.rotation.eulerAngles.z); 
        }

        private void SmoothFollow()
        {
            throw new NotImplementedException();
        }

        private void HandPositioning()
        {
            throw new NotImplementedException();
        }

        // 
        public void UpdateIndex(int length)
        {
            transform.SetSiblingIndex(parentCard.transform.parent.GetSiblingIndex());
        }

        private void Select(Card card)
        {
           
        }

        private void PointerUp(Card card)
        {

        }

        private void PointerDown(Card card)
        {

        }

        private void EndDrag(Card card)
        {
            
        }

        private void BeginDrag(Card card)
        {
          
        }

        private void PointerExit(Card card)
        {

        }

        private void PointerEnter(Card card)
        {

        }
    }
}