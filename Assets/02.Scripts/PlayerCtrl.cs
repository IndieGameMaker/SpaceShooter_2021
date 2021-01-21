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
        /*
            Input 클래스 
            - Keyboard, Mouse, Screen, JoyStick, VR Controller
            - Vertical
            - Horizontal
        */

        float v = Input.GetAxis("Vertical");  //W, S , Up, Down // -1.0f ~ 0.0f ~ +1.0f
        float h = Input.GetAxis("Horizontal"); //A, D, Left, Right
        Debug.Log($"h={h}, v={v}");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        
        transform.Translate(moveDir.normalized * Time.deltaTime *  moveSpeed);

        // transform.Translate(Vector3.forward * 0.1f * v);  //Vector3.forward = new Vector3(0, 0, 1)
        // transform.Translate(Vector3.right * 0.1f * h);

        /* 단위벡터 (Unit Vector), 정규화 벡터(Normalized Vector)
            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up      = Vector3(0, 1, 0)
            Vector3.right   = Vector3(1, 0, 0)

            Vector3.one     = Vector3(1, 1, 1)
            Vector3.zero    = Vector3(0, 0, 0)
        */
    }
}
