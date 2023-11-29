using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public bool firstBottomRoom = true;
	public bool firstTopRoom = true;
	public bool firstLeftRoom = true;
	public bool firstRightRoom = true;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	private float waitTime = 3f;
	public bool spawnedBoss;
	public GameObject boss;

	private AddRoom roomScript;


	void Update(){

		RenameRooms();

		if(waitTime <= 0 && spawnedBoss == false)
		{
			for (int i = 0; i < rooms.Count; i++) 
			{
				if(i == rooms.Count-1)
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
					
				}
			}
		} 
		else 
		{
			waitTime -= Time.deltaTime;
		}

	

	}

	void RenameRooms()
	{
		for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].name = "Room" + i;
			roomScript = rooms[i].GetComponent<AddRoom>();
			roomScript.NameText.text = "Room" + i;
        }
	}
}