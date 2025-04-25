using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Witch : MonoBehaviour
{
    private ISpellStrategy currentSpell;

    public WitchData witchData = new();
    [SerializeField] private ShieldSpellSO shieldSpellSO;

    private void Start()
    {
        witchData.Defence = 10;
        var shieldSpell = new ShieldSpellStrategy(witchData, shieldSpellSO);
        var spellContext = new SpellContext();
        ChangeSpell(shieldSpell);
        CastSpell();
    }

    public void ChangeSpell(ISpellStrategy spellStrategy)
    {
        currentSpell = spellStrategy;
    }

    public void CastSpell()
    {
        currentSpell?.Cast(this.transform);
    }
}

[System.Serializable]
public class WitchData
{
    public float Defence;
}

public class SpellContext
{
    //public AnimationController AnimationController { get; }
    public Transform ownerTransform { get; }
    public WitchData WitchData { get; }
    public Spell Spell;
}

public interface ISpellStrategy
{
    void Cast(Transform ownerTransform);
}

public class Spell : ScriptableObject,ISpellStrategy
{
    [SerializeField] protected ParticleSystem particleSystem;

    public virtual void Cast(Transform ownerTransform)
    {
    }
}

public class ShieldSpellStrategy : ISpellStrategy
{
    private WitchData witchData;
    private Spell spell;

    public ShieldSpellStrategy(WitchData witchData, Spell spell)
    {
        this.witchData = witchData;
        this.spell = spell;
    }

    public void Cast(Transform ownerTransform)
    {
        witchData.Defence += 10;
        spell.Cast(ownerTransform);
    }
}

[CreateAssetMenu(menuName = "Spells/Create ShieldSpell", fileName = "ShieldSpell", order = 0)]
public class ShieldSpellSO : Spell
{
    [SerializeField] private float duration;

    public override void Cast(Transform ownerTransform)
    {
        var shieldGo = Instantiate(particleSystem, ownerTransform);
        Destroy(shieldGo, duration);
    }
}