using UnityEngine;
using System.Collections;

public class DungeonMaster : Photon.MonoBehaviour
{
    public int playerCount;
    public GameObject monsterObj;
    public bool isControllable;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isControllable == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            { SpawnEnemy("Monster", Vector3.zero); }
        }
    }

    public void SpawnEnemy(string monster, Vector3 spawnSpot)
    { PhotonNetwork.Instantiate(monster, spawnSpot, Quaternion.identity, 0);

    }

    
}
