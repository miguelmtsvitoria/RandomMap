using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddRoom : MonoBehaviour {

	private RoomTemplates templates;
	public string key;
	public string roomType;
	public TextMeshProUGUI NameText;

	void Start(){

		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
	}

	public void NewKey(string KeyName)
    {
		key = KeyName;
    }
	

}