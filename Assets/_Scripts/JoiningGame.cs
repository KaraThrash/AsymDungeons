using UnityEngine;

public class JoiningGame : Photon.PunBehaviour
{
    private PhotonView myPhotonView;
    public int playerCount;
    public bool isDM;
    // Use this for initialization
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("JoinRandom");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        // when AutoJoinLobby is off, this method gets called when PUN finished the connection (instead of OnJoinedLobby())
        isDM = false;
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnPhotonRandomJoinFailed()
    {
        isDM = true;
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    {
        playerCount++;

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            print(SystemInfo.deviceType);
            //isMaster = true;
            if (isDM == true)
            {
                GameObject dm = PhotonNetwork.Instantiate("DungeonMaster", new Vector3(2,2,2), Quaternion.identity, 0);
                dm.GetComponent<DungeonMaster>().isControllable = true;
                myPhotonView = dm.GetComponent<PhotonView>();
                dm.GetComponent<Renderer>().material.color = Color.red;
                print("master");
            }
            else
            {
                GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
                player.GetComponent<PlayerMovement>().isControllable = true;
                myPhotonView = player.GetComponent<PhotonView>();
                player.GetComponent<Renderer>().material.color = Color.blue;
                print("Joined");
            }
        }
        else { }
        
    }

    
}
