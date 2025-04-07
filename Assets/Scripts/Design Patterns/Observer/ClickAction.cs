using System;
using UnityEngine;

namespace Design_Patterns.Observer
{
    public class ClickAction : MonoBehaviour
    {
        // Action with parameter
        // public event Action<int> OnClickAction;

        // Usage with UnityEvent
        // public UnityEvent OnClick;

        // Action invokable from other classes
        // public Action OnClickAction; 

        public event Action OnClickAction;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClickAction?.Invoke();
            }
        }
    }

    public class ClickListener : MonoBehaviour
    {
        [SerializeField] private ClickAction clickAction;
        private int clickCount;

        private void OnEnable()
        {
            clickAction.OnClickAction += IncreaseClickActionCount;
        }

        private void OnDisable()
        {
            clickAction.OnClickAction -= IncreaseClickActionCount;
        }

        private void IncreaseClickActionCount()
        {
            clickCount++;
            print("Click Count: " + clickCount);
        }
    }
}