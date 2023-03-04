using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    public CoinRotate Coin;
    private Queue<CoinRotate> Items = new Queue<CoinRotate>();
    public static ObjectPools Instance { get; set; }

    private void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CoinRotate Get()
    {
        if(Items.Count == 0){
            var obstacle = Instantiate(Coin);
            obstacle.gameObject.SetActive(false);
            Items.Enqueue(obstacle);
        }
        return Items.Dequeue();
    }

    public void ReturnToPool(CoinRotate obj){
        obj.gameObject.SetActive(false);
        Items.Enqueue(obj);
    }
}
