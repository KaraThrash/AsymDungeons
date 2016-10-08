using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collision col)
    { if (col.gameObject.tag == "Player")
        { anim.SetTrigger("Activate"); }

                }
    public void DieNow()
    { Destroy(this.gameObject); }
}
