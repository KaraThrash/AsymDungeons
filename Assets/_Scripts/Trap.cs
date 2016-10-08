using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {
    private Animator anim;
    public GameObject myIndicator;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
       //GameObject clone = Instantiate(myIndicator,new Vector3(transform.position.x * 0.1f,transform.y + 20, transform.position.z * 0.1f),transform.rotation);
        myIndicator.transform.position = new Vector3(transform.position.x * 0.1f, 21f, transform.position.z * 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collision col)
    { if (col.gameObject.tag == "Player")
        { anim.SetTrigger("Activate"); }

                }

    public void DieNow()
    {

        Destroy(this.gameObject); }
}
