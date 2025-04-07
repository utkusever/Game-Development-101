using System.Collections.Generic;
using UnityEngine;

namespace Design_Patterns.Object_Pooling
{
    public class GenericObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private protected int count;
        [SerializeField] private protected T objectToPool;
        protected Queue<T> pooledObjects = new Queue<T>();
        protected List<T> objectsInUse = new List<T>();

        protected virtual void InitializePool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var item = Instantiate(objectToPool, this.transform);
                item.gameObject.SetActive(false);
                pooledObjects.Enqueue(item);
            }
        }

        public virtual T GetFromPool()
        {
            if (pooledObjects.Count > 0)
            {
                T itemToReturn = pooledObjects.Dequeue();
                objectsInUse.Add(itemToReturn);
                itemToReturn.gameObject.SetActive(true);
                return itemToReturn;
            }

            return CreateNewPooledItem();
        }

        protected virtual T CreateNewPooledItem()
        {
            T newPooledItem = Instantiate(objectToPool, this.transform);
            objectsInUse.Add(newPooledItem);
            return newPooledItem;
        }

        public virtual void ReturnToPool(T item)
        {
            item.gameObject.SetActive(false);
            pooledObjects.Enqueue(item);
            objectsInUse.Remove(item);
        }

        public virtual void ReturnAllItemsToPool()
        {
            foreach (var item in objectsInUse)
            {
                item.gameObject.SetActive(false);
                pooledObjects.Enqueue(item);
            }

            objectsInUse.Clear();
        }
    }

    public class EnemySpawnerPool : GenericObjectPool<Enemy>
    {
        private void Awake()
        {
            InitializePool(count);
        }

        protected override void InitializePool(int count)
        {
            base.InitializePool(count);
            // var itemToReturn = pooledObjects.Dequeue();
            // //itemToReturn.SetPool();
            // pooledObjects.Enqueue(itemToReturn);
        }
    }
}