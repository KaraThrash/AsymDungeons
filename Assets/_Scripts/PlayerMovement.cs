using UnityEngine;
using System.Collections;

public class PlayerMovement : Photon.MonoBehaviour
{
    public bool isControllable;
    public float speed;
	// Use this for initialization
	void Start () {
        
        GetComponent<Renderer>().material.color = Color.blue;

    }
	
	// Update is called once per frame
	void Update () {
        if (isControllable == true)
        { Move(); }

    }
    
    public void Move()
    {
        if (Input.GetKey(KeyCode.D))
        { transform.Translate(Vector3.right * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A))
        { transform.Translate(Vector3.left * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.W))
        { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S))
        { transform.Translate(Vector3.forward * -speed * Time.deltaTime); }
    }
}
