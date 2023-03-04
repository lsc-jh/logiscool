using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    private bool spawning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItems());
        Debug.Log("AfterStart");
    }

    IEnumerator SpawnItems(){
        while(true){
            if(spawning){
                var obs = ObjectPools.Instance.Get();
                obs.transform.position = obstacle.GetComponentInChildren<Transform>().GetChild(Random.Range(0, 4)).position;
                obs.transform.rotation = transform.rotation;
                obs.gameObject.SetActive(true);
                Debug.Log("asd");
            }
            else{
                Debug.Log("asd123S");
                Instantiate(obstacle);
            }

            spawning = !spawning;

            Debug.Log("BeforeYeild");
            yield return new WaitForSeconds(10f / PlayerController.speed);
        }
    }
}
