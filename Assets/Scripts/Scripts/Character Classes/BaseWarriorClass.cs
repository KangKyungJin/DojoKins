using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarriorClass : BaseCharacterClass
{
    public BaseWarriorClass()
    {
        CharacterClassName = "Warrior";
        CharacterClassDescription = "Win ties";
        CharacterGender = "Male";
        Level = 1;
        Strength = 0;
        Death = false;
    }
}
