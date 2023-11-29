using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public bool locked = false;
    public string source;
    public string destination;
    public bool bidirectional = true;
    public string keyNeeded;
    public bool blocked = true;

    public GameObject Green;
    public GameObject GreenBidirectional;
    public GameObject GreenUnidirectional;
    public GameObject Red;
    public GameObject RedBidirectional;
    public GameObject RedUnidirectional;
    public GameObject Key;
    private RoomTemplates allRooms;
    private AddRoom room;
    private int rand;
    private int rand2;
    private string keyName;
    private bool doOnce = true;

    void Start()
    {
        rand2 = Random.Range(1, 10);
        if(rand2 < 8)
        {
            bidirectional = true;

            RedBidirectional.SetActive(false);
            RedUnidirectional.SetActive(false);
            GreenBidirectional.SetActive(true);
            GreenUnidirectional.SetActive(false);
        } 
        else
        {
            bidirectional = false;

            RedBidirectional.SetActive(false);
            RedUnidirectional.SetActive(false);
            GreenBidirectional.SetActive(false);
            GreenUnidirectional.SetActive(true);
        }

        Red.SetActive(false);
        Green.SetActive(true);
    }

    public void LockTransition()
    {
        if(locked == false)
        {
            locked = true;
            Red.SetActive(true);
            Green.SetActive(false);

            if(bidirectional)
            {
                RedBidirectional.SetActive(true);
                GreenUnidirectional.SetActive(false);
                GreenBidirectional.SetActive(false);
            }
            else
            {
                RedUnidirectional.SetActive(true);
                GreenUnidirectional.SetActive(false);
                GreenBidirectional.SetActive(false);
            }

            SpawnKey();
        }
    }

    public void SpawnKey()
    {
        allRooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        rand = Random.Range(1, allRooms.rooms.Count - 1);       // -1 para não spawnar chave no destino & 1 para não spawnar na entry room (0)
        room = allRooms.rooms[rand].GetComponent<AddRoom>();      // falta verificar se a sala ja tem chave

        while(room.key != "")
        {
            rand = Random.Range(1, allRooms.rooms.Count - 1);
            room = allRooms.rooms[rand].GetComponent<AddRoom>();
        }
        
        GameObject[] allKeys = GameObject.FindGameObjectsWithTag("Key");
        keyName = "Key" + allKeys.Length;
        room.NewKey(keyName);
        keyNeeded = keyName;
        Instantiate(Key, allRooms.rooms[rand].transform.position, allRooms.rooms[rand].transform.rotation);
    }

    void Update()
    {
        GameObject square1 = GameObject.Find(source);
        GameObject square2 = GameObject.Find(destination);

        if (square1 != null && square2 != null && doOnce)
        {
            float square1Y = square1.transform.position.y;
            float square2Y = square2.transform.position.y;
            float square1X = square1.transform.position.x;
            float square2X = square2.transform.position.x;

            if (square1Y > square2Y)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else if (square1Y < square2Y)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            }

            if (square1X < square2X && !bidirectional)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            }
            doOnce = false;
        }

    }

}
