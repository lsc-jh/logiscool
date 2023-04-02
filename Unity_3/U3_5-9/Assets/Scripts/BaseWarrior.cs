using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarrior : BaseClassScript
{
    public BaseWarrior()
    {
        ClassName = "Warrior";
        Health = 10;
        Strength = 5;
        Agility = 3;
        Intelligence = 2;
        Damage = Strength * 5;
        Shoot = false;
    }
}
