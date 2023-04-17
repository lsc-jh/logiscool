using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArcher : BaseClassScript
{
    public BaseArcher()
    {
        ClassName = "Archer";
        Health = 8;
        Strength = 5;
        Agility = 4;
        Intelligence = 3;
        Damage = Strength * 3;
        Shoot = true;
    }
}
