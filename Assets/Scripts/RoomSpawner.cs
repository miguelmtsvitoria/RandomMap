using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door

	private RoomTemplates templates;
	private AddRoom roomTypeScript;
	private int rand;
	private bool spawned = false;
	private bool forcedSpawn = false;
	private bool dontGoR = false;
	private bool dontGoL = false;
	private bool dontGoT = false;
	private bool dontGoB = false;

	//transform.parent.parent.position

	void Start(){
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}


	void Spawn()
	{
		if(spawned == false)
		{
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				if(templates.firstBottomRoom)
				{
					Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
					templates.firstBottomRoom = false;
				}
				else
				{
					for (int i = 0; i < templates.rooms.Count; i++)
					{
						if(templates.rooms[i].transform.position.x == (transform.position.x - 10) && templates.rooms[i].transform.position.y == (transform.position.y + 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "R" || roomTypeScript.roomType == "RB" || roomTypeScript.roomType == "LR" || roomTypeScript.roomType == "TR")
							{
								Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoL = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.x + 10) && templates.rooms[i].transform.position.y == (transform.position.y + 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "TL" || roomTypeScript.roomType == "BL" || roomTypeScript.roomType == "LR" || roomTypeScript.roomType == "L")
							{
								Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoR = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.x) && templates.rooms[i].transform.position.y == (transform.position.y + 20))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "B" || roomTypeScript.roomType == "BL" || roomTypeScript.roomType == "TB" || roomTypeScript.roomType == "RB")
							{
								Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoT = true;
						}
						
					}

					if(forcedSpawn == false)
					{
						if(SceneManager.GetActiveScene().buildIndex == 1) // small map
						{
							if(dontGoL && dontGoR && dontGoT)
							{
								Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoR)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoT)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoR && dontGoT)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 5)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							
						}
						else if(SceneManager.GetActiveScene().buildIndex == 2) // medium map
						{
							if(dontGoL && dontGoR && dontGoT)
							{
								Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoR)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoT)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoR && dontGoT)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
							}
							
						}
						if(SceneManager.GetActiveScene().buildIndex == 3) // big map
						{
							if(dontGoL && dontGoR && dontGoT)
							{
								Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoR)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
							}
							else if(dontGoL && dontGoT)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
							}
							else if(dontGoR && dontGoT)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
								if(rand == 5)
									Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
							}
							
						}
						
					}
				}
				
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				if(templates.firstTopRoom)
				{
					Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
					templates.firstTopRoom = false;
				}
				else
				{
					for (int i = 0; i < templates.rooms.Count; i++)
					{
						if(templates.rooms[i].transform.position.x == (transform.position.x - 10) && templates.rooms[i].transform.position.y == (transform.position.y - 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "R" || roomTypeScript.roomType == "RB" || roomTypeScript.roomType == "LR" || roomTypeScript.roomType == "TR")
							{
								Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoL = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.x + 10) && templates.rooms[i].transform.position.y == (transform.position.y - 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "TL" || roomTypeScript.roomType == "BL" || roomTypeScript.roomType == "LR" || roomTypeScript.roomType == "L")
							{
								Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoR = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.x) && templates.rooms[i].transform.position.y == (transform.position.y - 20))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "TR" || roomTypeScript.roomType == "TL" || roomTypeScript.roomType == "TB" || roomTypeScript.roomType == "T")
							{
								Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoB = true;
						}
						
					}

					if(forcedSpawn == false)
					{
						if(SceneManager.GetActiveScene().buildIndex == 1) // small map
						{
							if(dontGoL && dontGoR && dontGoB)
							{
								Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoR)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoR && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 5)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							
						}
						else if(SceneManager.GetActiveScene().buildIndex == 2) // medium map
						{
							if(dontGoL && dontGoR && dontGoB)
							{
								Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoR)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoB)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoR && dontGoB)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
							}
							
						}
						if(SceneManager.GetActiveScene().buildIndex == 3) // big map
						{
							if(dontGoL && dontGoR && dontGoB)
							{
								Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoR)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
							}
							else if(dontGoL && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
							}
							else if(dontGoR && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.topRooms[1], transform.position, templates.topRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.topRooms[2], transform.position, templates.topRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
								if(rand == 5)
									Instantiate(templates.topRooms[3], transform.position, templates.topRooms[3].transform.rotation);
							}
							
						}
						
					}
				}				

			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				if(templates.firstLeftRoom)
				{
					Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
					templates.firstLeftRoom = false;
				}
				else
				{
					for (int i = 0; i < templates.rooms.Count; i++)
					{
						if(templates.rooms[i].transform.position.x == (transform.position.x + 10) && templates.rooms[i].transform.position.y == (transform.position.y + 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "B" || roomTypeScript.roomType == "BL" || roomTypeScript.roomType == "TB" || roomTypeScript.roomType == "RB")
							{
								Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoT = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.x + 10) && templates.rooms[i].transform.position.y == (transform.position.y - 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "TR" || roomTypeScript.roomType == "TL" || roomTypeScript.roomType == "TB" || roomTypeScript.roomType == "T")
							{
								Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoB = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.y) && templates.rooms[i].transform.position.y == (transform.position.x + 20))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "TL" || roomTypeScript.roomType == "BL" || roomTypeScript.roomType == "LR" || roomTypeScript.roomType == "L")
							{
								Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoR = true;
						}
						
					}

					if(forcedSpawn == false)
					{
						if(SceneManager.GetActiveScene().buildIndex == 1) // small map
						{
							if(dontGoT && dontGoR && dontGoB)
							{
								Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoR)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoR && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 5)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							
						}
						else if(SceneManager.GetActiveScene().buildIndex == 2) // medium map
						{
							if(dontGoT && dontGoR && dontGoB)
							{
								Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoR)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoB)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoR && dontGoB)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
							}
							
						}
						if(SceneManager.GetActiveScene().buildIndex == 3) // big map
						{
							if(dontGoT && dontGoR && dontGoB)
							{
								Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoR)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
							}
							else if(dontGoT && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
							}
							else if(dontGoR && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
							}
							else if(dontGoR)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
								if(rand == 4)
									Instantiate(templates.leftRooms[3], transform.position, templates.leftRooms[3].transform.rotation);
								if(rand == 5)
									Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
							}
							
						}
						
					}
				}
				
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				if(templates.firstRightRoom)
				{
					Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
					templates.firstRightRoom = false;
				}
				else
				{
					for (int i = 0; i < templates.rooms.Count; i++)
					{
						if(templates.rooms[i].transform.position.x == (transform.position.x - 10) && templates.rooms[i].transform.position.y == (transform.position.y + 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "B" || roomTypeScript.roomType == "BL" || roomTypeScript.roomType == "TB" || roomTypeScript.roomType == "RB")
							{
								Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoT = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.x - 10) && templates.rooms[i].transform.position.y == (transform.position.y - 10))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "TL" || roomTypeScript.roomType == "TR" || roomTypeScript.roomType == "TB" || roomTypeScript.roomType == "T")
							{
								Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoB = true;
						}
						else if(templates.rooms[i].transform.position.x == (transform.position.y) && templates.rooms[i].transform.position.y == (transform.position.x - 20))
						{
							roomTypeScript = templates.rooms[i].GetComponent<AddRoom>();
							if(roomTypeScript.roomType == "R" || roomTypeScript.roomType == "RB" || roomTypeScript.roomType == "TR" || roomTypeScript.roomType == "LR")
							{
								Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								forcedSpawn = true;
								//Debug.Log("X = " + transform.position.x + "       Y = " + transform.position.y);
							}
							dontGoL = true;
						}
						
					}

					if(forcedSpawn == false)
					{
						if(SceneManager.GetActiveScene().buildIndex == 1) // small map
						{
							if(dontGoT && dontGoL && dontGoB)
							{
								Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoL)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 5)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							
						}
						else if(SceneManager.GetActiveScene().buildIndex == 2) // medium map
						{
							if(dontGoT && dontGoL && dontGoB)
							{
								Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoL)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoB)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoL && dontGoB)
							{
								rand = Random.Range(0, 2);
								if(rand == 0)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 3);
								if(rand == 0)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
							}
							
						}
						if(SceneManager.GetActiveScene().buildIndex == 3) // big map
						{
							if(dontGoT && dontGoL && dontGoB)
							{
								Instantiate(templates.rightRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
							}
							else if(dontGoT && dontGoL)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
							}
							else if(dontGoT && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
							}
							else if(dontGoL && dontGoB)
							{
								rand = Random.Range(0, 4);
								if(rand == 0)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
							}
							else if(dontGoL)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
							}
							else if(dontGoT)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
							}
							else if(dontGoB)
							{
								rand = Random.Range(0, 5);
								if(rand == 0)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
							}
							else
							{
								rand = Random.Range(0, 6);
								if(rand == 0)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 1)
									Instantiate(templates.rightRooms[1], transform.position, templates.rightRooms[1].transform.rotation);
								if(rand == 2)
									Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
								if(rand == 3)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
								if(rand == 4)
									Instantiate(templates.rightRooms[3], transform.position, templates.rightRooms[3].transform.rotation);
								if(rand == 5)
									Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
							}
							
						}
						
					}		
				}		

			}
			spawned = true;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint"))
		{
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				//Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} 
			spawned = true;
		}
	}
}