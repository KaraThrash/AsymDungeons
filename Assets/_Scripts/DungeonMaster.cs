using UnityEngine;
using System.Collections;

public class DungeonMaster : Photon.MonoBehaviour
{
    public bool monsterSelected;
    public string monsterName;
    public string trapName;


    public int playerCount;
    public GameObject monsterObj;
    public bool isControllable;

    public GameObject dmCamera;
    public GameObject cameraHolder;
    public GameObject player;
    public GameObject wayPoint;
    public GameObject dmUI;
    public GameObject canvasObj;
    public GameObject dmPowerManager;
    public float delay;
    bool one_click = false;
    bool timer_running;
    public float time_for_double_click;

    // Use this for initialization
    void Start()
    {
        canvasObj = GameObject.Find("Canvas");
        dmUI = canvasObj.transform.Find("DmUI").gameObject;
        dmCamera = GameObject.Find("DMCamera");
        if (isControllable == true)
        {
            dmPowerManager = GameObject.Find("DMPowerManager");
            dmPowerManager.GetComponent<DMPowerManager>().dm = this.gameObject;
            dmUI.active = true;
        }
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
                Ray ray = dmCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Ground")
                    {

                        //wayPoint.transform.position = hit.point;
                        SpawnEnemy(monsterName, hit.point);
                       // SpawnEnemy(monsterName, new Vector3(hit.point.x * 10, hit.point.y - 10, hit.point.z * 10));
                    }

                }
            }

        }
    }

    public void SpawnEnemy(string monster, Vector3 spawnSpot)
    { PhotonNetwork.Instantiate(monster, spawnSpot, Quaternion.identity, 0);

    }

    
}
