using UnityEngine;

namespace Design_Patterns.Strategy
{
    public class Witch : MonoBehaviour
    {
        private ISpellStrategy currentSpell;

        private void Start()
        {
            var speller = new Speller(this.transform);
            speller.ChangeSpell(new ShieldSpell());
            speller.CastSpell();
            speller.ChangeSpell(new ImmuneSpell());
            speller.CastSpell();
        }
    }

// it can be abstract class scriptable object etc. main focus is common method
    public interface ISpellStrategy
    {
        void Cast(Transform ownerTransform);
    }

    public class ShieldSpell : ISpellStrategy
    {
        public void Cast(Transform ownerTransform)
        {
            Debug.Log("Shield Spell Instantiated etc.");
        }
    }

    public class ImmuneSpell : ISpellStrategy
    {
        public void Cast(Transform ownerTransform)
        {
            Debug.Log("Immune Spell Activated for 5 sec. etc.");
        }
    }

    public class Speller
    {
        private ISpellStrategy currentSpell;
        private Transform ownerTransform;

        public Speller(Transform transform)
        {
            ownerTransform = transform;
        }

        public void ChangeSpell(ISpellStrategy spellStrategy)
        {
            currentSpell = spellStrategy;
        }

        public void CastSpell()
        {
            currentSpell?.Cast(ownerTransform);
        }
    }

    [CreateAssetMenu(menuName = "Create Spell", fileName = "Spell", order = 0)]
    public class SpellSO : ScriptableObject, ISpellStrategy
    {
        [SerializeField] protected ParticleSystem particleSystem;
        [SerializeField] private float duration;

        public virtual void Cast(Transform ownerTransform)
        {
            var shieldGo = Instantiate(particleSystem, ownerTransform);
            Destroy(shieldGo, duration);
        }
    }
}