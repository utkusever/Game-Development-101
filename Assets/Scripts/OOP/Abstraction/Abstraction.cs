using UnityEngine;

public class Abstraction : MonoBehaviour
{
    //Abstraction aims to hide unnecessary details and only provide the necessary information.
    //It allows building large systems without increasing code complexity or understanding.
    private void Start()
    {
        CharacterDataBuilder characterDataBuilder = new CharacterDataBuilder();
        var data = characterDataBuilder.GetCharacterData();
        Character character = new Character(data);
        var characterStat = character.GetCharacterStat();
        print(characterStat.HP);
        print(characterStat.ATK);
        print(characterStat.DEF);
    }

    private class Character
    {
        private Stat myStat;

        public Character(Stat stat)
        {
            myStat = stat;
        }

        public Stat GetCharacterStat()
        {
            return myStat;
        }
    }

    private class CharacterDataBuilder
    {
        private Stat stat;

        public Stat GetCharacterData()
        {
            stat = new Stat();
            SetHp();
            SetAtk();
            SetDef();
            return stat;
        }

        private void SetHp()
        {
            stat.HP = 10;
        }

        private void SetAtk()
        {
            stat.ATK = 2;
        }

        private void SetDef()
        {
            stat.DEF = (int)(stat.HP / 1.5);
        }
    }

    private struct Stat
    {
        public int HP;
        public int ATK;
        public int DEF;
    }
}