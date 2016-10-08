using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public int playerCount;
    public GameObject monsterObj;
    public bool isMaster;

	// Use this for initialization
	void Start () {
        
        if (SystemInfo.deviceType == DeviceType.Desktop)
        { print(SystemInfo.deviceType);
            //isMaster = true;
        }
        

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && isMaster == true)
        {
            //CmdSpawn(monsterObj,transform.position);

            GameObject clone = (GameObject)Instantiate(monsterObj, transform.position, monsterObj.transform.rotation);
            NetworkServer.Spawn(clone);
        }
    }
    void OnPlayerConnected(NetworkPlayer player)
    {
        print("Player " + playerCount++ + " connected from " + player.ipAddress + ":" + player.port);
    }
    [Command]
    private void CmdSpawn(GameObject monster, Vector3 spawnSpot)
    {
        GameObject clone = (GameObject)Instantiate(monster, transform.position, transform.rotation);
        NetworkServer.Spawn(monster);
        // Create an instance of the shell and store a reference to it's rigidbody.
        //GameObject NewMonster =
          //   Network.Instantiate(monster, spawnSpot, monster.transform.rotation, 0) as GameObject;

        // Create a velocity that is the tank's velocity and the launch force in the fire position's forward direction.
        //Vector3 velocity = rigidbodyVelocity + launchForce * forward;

        // Set the shell's velocity to this velocity.
        //shellInstance.velocity = velocity;

        //NetworkServer.Spawn(NewMonster);
    }
}
