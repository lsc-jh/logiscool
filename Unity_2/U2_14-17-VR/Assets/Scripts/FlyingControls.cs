using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlyingControls : MonoBehaviour
{

    public float baseSpeed;

    private float speed;

    public Image blackScreen;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = baseSpeed + GvrVRHelpers.GetHeadRotation().x * 10;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + GvrVRHelpers.GetHeadForward(), speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        baseSpeed = 0;
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => blackScreen.color.a == 1);
        SceneManager.LoadScene("SampleScene");
    }
}
