using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private PhotonView myPhotonView;
    public GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

        if (player != null)
        { transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); }
	}
}
