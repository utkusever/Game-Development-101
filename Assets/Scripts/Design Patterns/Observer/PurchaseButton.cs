using System;
using UnityEngine;
using UnityEngine.UI;

namespace Design_Patterns.Observer
{
    public class PurchaseButton : NotifierSubject
    {
        [SerializeField] private Button purchaseButton;
        private int purchaseCount;

        private void OnEnable()
        {
            purchaseButton.onClick.AddListener(HandlePurchase);
        }

        private void OnDisable()
        {
            purchaseButton.onClick.RemoveListener(HandlePurchase);
        }

        private void HandlePurchase()
        {
            purchaseCount++;
            base.NotifyObservers();
        }

        public int GetPurchaseCount()
        {
            return purchaseCount;
        }
    }
}