using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
 
        float v = Input.GetAxis("Vertical");  //W, S , Up, Down // -1.0f ~ 0.0f ~ +1.0f
        float h = Input.GetAxis("Horizontal"); //A, D, Left, Right
        Debug.Log($"h={h}, v={v}");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        
        transform.Translate(moveDir.normalized * Time.deltaTime *  moveSpeed);

        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.1f);
        }
    }
}
