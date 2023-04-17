using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClassScript : MonoBehaviour, IClass
{
    private string _className;
    public int Health { get; set; }
    public int Strength { get;set; }
    public int Damage { get; set; }
    public int Agility {get; set; }
    public int Intelligence { get; set; }
    public bool Shoot { get; set; }
    
    public string ClassName
    {
        get { return _className; }
        set { _className = value; }
    }
}
