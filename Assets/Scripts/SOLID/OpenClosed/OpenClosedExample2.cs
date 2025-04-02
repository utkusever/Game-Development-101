using UnityEngine;

namespace SOLID.OpenClosed
{
    public class OpenClosedExample2 : MonoBehaviour
    {
        public interface IHealth
        {
            public int Health { get; set; }
        }

        public interface IArea
        {
            void OnCollision(IHealth health);
        }

        public abstract class Health : MonoBehaviour
        {
        }

        public class PlayerHealth : Health, IHealth
        {
            [SerializeField] private int health;

            public int Health
            {
                get => health;
                set => health = value;
            }
        }

        public class PlayerCollisionChecker : MonoBehaviour
        {
            private IHealth playerHealth;

            private void Start()
            {
                playerHealth = this.GetComponent<IHealth>();
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.TryGetComponent(out IArea area))
                {
                    area.OnCollision(playerHealth);
                }
            }
            
            // Don't do this, this is not closed. We have to modify/update here when we add more area to game/project
            // private void OnTriggerEnter(Collider other)
            // {
            //     if (other.CompareTag("FireArea"))
            //     {
            //         playerHealth.Health--;
            //     }
            //
            //     if (other.CompareTag("HealArea"))
            //     {
            //         playerHealth.Health++;
            //     }
            // }
        }

        public class FireArea : MonoBehaviour, IArea
        {
            public void OnCollision(IHealth otherHealth)
            {
                otherHealth.Health--;
            }
        }

        public class HealArea : MonoBehaviour, IArea
        {
            public void OnCollision(IHealth otherHealth)
            {
                otherHealth.Health++;
            }
        }
    }
}