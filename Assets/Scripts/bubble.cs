using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    // Start is called before the first frame update\
    public Boolean moving = true;
    void Start()
    {
        if (moving)
            StartCoroutine(RunLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision for bubble");
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
    
    private IEnumerator RunLoop() {
        float pingPongSpeed = 0.25f;
        for (float t=0f; ; t += Time.deltaTime) { 
            float y = Mathf.PingPong(Time.time * pingPongSpeed, 1) * 3f - 1.5f;
            transform.position = new Vector3(y, transform.position.y, transform.position.z);
            yield return null; // "wait for a frame"
        }
    }
    
}
