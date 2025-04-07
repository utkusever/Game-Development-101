using System.Collections.Generic;
using UnityEngine;

namespace Design_Patterns.Observer
{
    public class NotifierSubject : MonoBehaviour
    {
        private List<IObserver> observers = new();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        protected void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.OnNotify();
            }
        }
    }
}