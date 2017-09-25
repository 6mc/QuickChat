using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;  
using System;
using UnityEngine.UI;
using System.Linq;
using SocketIO;


public class initialize : MonoBehaviour {

public SocketIOComponent socket;

	public Text first;
public Text first1;
public Text first2;
public Text first3;
public Text first4;
public Text first5;
public Text first6;
public Text first7;
public Text[] obez;
public InputField inputfieldname;

void Start () {
		

		StartCoroutine(ConnectToServer());

		socket.On("user_connected", OnUserConnected);
	//		socket.On("PLAY", OnUserPlay);
	}





IEnumerator ConnectToServer(){

		yield return new WaitForSeconds(0.5f);

		socket.Emit("user_connect");

		yield return new WaitForSeconds(1f);
		 Dictionary<string, string> data = new Dictionary<string, string>();

data["name"]=first.text;
data["position"]= first.text;

		socket.Emit("PLAY", new JSONObject(data) );
	}



private void OnUserConnected(SocketIOEvent evt ){

Debug.Log("server from message is "+evt.data);

}
private void OnUserPlay(SocketIOEvent evt ){

Debug.Log("the message from server is  "+evt.data);

//first.text = evt.data["name"].ToString();


inputfieldname.Select();
inputfieldname.text="";

}


public void disp(SocketIOEvent evt)
{}

public void revolt()
{

StartCoroutine(ConnectToServer());

		
		socket.On("PLAY", OnUserPlay);

//inputfieldname.Select();
//inputfieldname.text="";

}


public void	 slide()
{
obez = new Text[10];

obez[0] = first;
obez[1] = first1;
obez[2] = first2;
obez[3] = first3;
obez[4] = first4;
obez[5] = first5;
obez[6] = first6;
obez[7] = first7;

for (int i = 7; i > 0; i--)
       {

obez[i].text = obez[i-1].text;

                  }

//first1.text = evt.data["name"].ToString();



//inputfieldname.Select();
//inputfieldname.text="";

}


}
