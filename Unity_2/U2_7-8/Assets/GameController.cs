using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject blockPrefab;
    public List<GameObject> blocks;
    public GuiScript gui;
    private Vector2 blockPos;
    int amount = 16;
    float xPos, screenX;

    // Start is called before the first frame update
    void Start()
    {
        screenX = Vector2.Distance(
            Camera.main.ScreenToWorldPoint(new Vector2(0, 0)),
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0) * 0.5f));
        SpawnBlocks();
    }

    public void SpawnBlocks()
    {
        xPos = (Camera.main.transform.position.x - screenX) + 0.5f;
        blockPos = new Vector3(xPos, 3f);
        blocks.Add(Instantiate(blockPrefab, blockPos, Quaternion.identity, transform));
        for (int i = 0; i < amount - 1; i++)
        {
            xPos += 1f;
            if (Random.Range(1, 100) >= 30)
            {
                blockPos = new Vector3(xPos, 3f);
                blocks.Add(Instantiate(blockPrefab, blockPos, Quaternion.identity, transform));
            }
        }
    }
    
    public void CheckPos()
    {
        gui.tempPoint = 0;
        foreach(GameObject item in blocks)
        {
            if(item != null)
            {
                item.transform.position = new Vector2(item.transform.position.x, item.transform.position.y - 1f);
                if(item.transform.position.y <= -5f)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                }
            }
            if(item == null)
            {
                gui.tempPoint += 100;
                gui.point = gui.tempPoint;
                if(gui.point >= 10000)
                    SceneManager.LoadScene("SampleScene");
            }
        }
        SpawnBlocks();

    }
}
