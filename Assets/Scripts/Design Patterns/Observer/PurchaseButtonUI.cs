using System;
using TMPro;
using UnityEngine;

namespace Design_Patterns.Observer
{
    public class PurchaseButtonUI : MonoBehaviour, IObserver
    {
        [SerializeField] private PurchaseButton purchaseButton;
        [SerializeField] private TMP_Text purchaseCountText;

        private void Start()
        {
            SetPurchaseCountText();
            purchaseButton.AddObserver(this);
        }

        private void OnDestroy()
        {
            purchaseButton.RemoveObserver(this);
        }

        public void OnNotify()
        {
            SetPurchaseCountText();
        }

        private void SetPurchaseCountText()
        {
            purchaseCountText.text = purchaseButton.GetPurchaseCount().ToString();
        }
    }
}