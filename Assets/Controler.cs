using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System.Text;
using System;
using UnityEngine.UI;
using System.Linq;

public class Controler : MonoBehaviour {

public Text first;

public SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		

	//	StartCoroutine(ConnectToServer());

	//	socket.On("user_connected", OnUserConnected);
	//	socket.On("PLAY", OnUserPlay);
	}


	IEnumerator ConnectToServer(){

		yield return new WaitForSeconds(0.5f);

		socket.Emit("user_connect");

		yield return new WaitForSeconds(1f);
		 Dictionary<string, string> data = new Dictionary<string, string>();

data["name"]="memoli";
data["position"]= first.text;

		socket.Emit("PLAY", new JSONObject(data) );
	}
	

private void OnUserConnected(SocketIOEvent evt ){

Debug.Log("server from message is "+evt.data);

}
private void OnUserPlay(SocketIOEvent evt ){

Debug.Log("the message from server is  "+evt.data);

first.text = evt.data["name"].ToString();

}

public void disp(SocketIOEvent evt)
{





}


	// Update is called once per frame
	void Update () {

		
		
	}
}
