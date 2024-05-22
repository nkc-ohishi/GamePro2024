using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10;            // ˆÚ“®‘¬“x‚ğ•Û‘¶‚·‚é•Ï”
        Vector3 dir = Vector3.zero; // ˆÚ“®•ûŒü‚ğ•Û‘¶‚·‚é•Ï”

        // ã‰º¶‰EˆÚ“®
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
