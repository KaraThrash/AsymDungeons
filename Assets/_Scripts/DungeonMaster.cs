using UnityEngine;
using System.Collections;

public class DungeonMaster : Photon.MonoBehaviour
{
    public string monsterName;
    public int playerCount;
    public GameObject monsterObj;
    public bool isControllable;

    
    public GameObject cameraHolder;
    public GameObject player;
    public GameObject wayPoint;
   

    public float delay;
    bool one_click = false;
    bool timer_running;
    public float time_for_double_click;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (isControllable == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            { SpawnEnemy(monsterName, Vector3.zero); }


            if (Input.GetMouseButtonDown(0))
            {
                if (!one_click)
                { // first click no previous clicks
                    one_click = true;

                    time_for_double_click = Time.time; // save the current time
                                                       // do one click things;
                }
                else
                {

                    one_click = false; // found a double click, now reset
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.tag == "Ground")
                        {

                            //wayPoint.transform.position = hit.point;

                            SpawnEnemy(monsterName, hit.point);
                        }

                    }
                    if (one_click)
                    {
                        // if the time now is delay seconds more than when the first click started. 
                        if ((Time.time - time_for_double_click) > delay)
                        {

                            //basically if thats true its been too long and we want to reset so the next click is simply a single click and not a double click.

                            one_click = false;

                        }

                    }
                }
            }
        }
    }

    public void SpawnEnemy(string monster, Vector3 spawnSpot)
    { PhotonNetwork.Instantiate(monster, spawnSpot, Quaternion.identity, 0);

    }

    
}
