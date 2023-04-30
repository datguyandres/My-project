using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//************** use UnityOSC namespace...
using UnityOSC;
//*************
public class WeDoALittleAudioHandling : MonoBehaviour
{
    public Text countText;
    public int count;

    //************* Need to setup this server dictionary...
	Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog> ();
	//*************


    // Start is called before the first frame update
    void Start()
    {
		Application.runInBackground = true; //allows unity to update when not in focus

		//************* Instantiate the OSC Handler...
	    OSCHandler.Instance.Init ();
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/trigger", "ready");
        //*************
		//OSCHandler.Instance.SendMessageToClient("pd", "/unity/BGM", 1); bgm would go here

        
    }


    void FixedUpdate()
	{
		//************* Routine for receiving the OSC...
		OSCHandler.Instance.UpdateLogs();
		Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
		servers = OSCHandler.Instance.Servers;

		foreach (KeyValuePair<string, ServerLog> item in servers) {
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if (item.Value.log.Count > 0) {
				int lastPacketIndex = item.Value.packets.Count - 1;

				//get address and data packet
				countText.text = item.Value.packets [lastPacketIndex].Address.ToString ();
				countText.text += item.Value.packets [lastPacketIndex].Data [0].ToString ();

			}
		}
		//*************
	}

	public void playcoinPickup(){
		// trigger noise burst whe hitting a wall.
        // OSCHandler.Instance.SendMessageToClient("pd", "/unity/PickUpCoin", 1);
	}

	public void PlayjumpSound(){
		//trigger noise burst whe hitting a wall.
        // OSCHandler.Instance.SendMessageToClient("pd", "/unity/Jump", 1);
	}


    void setCountText()
	{
        countText.text = "Count: " + count.ToString();

        //************* Send the message to the client...
        OSCHandler.Instance.SendMessageToClient ("pd", "/unity/trigger", count);
        //*************


    }
}
