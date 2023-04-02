using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClassScript : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
