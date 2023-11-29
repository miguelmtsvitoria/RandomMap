using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;  //biblioteca adicionada
// instanciar isto só quando estiver tudo gerado


public class XMLGenerator : MonoBehaviour
{
    private RoomTemplates roomsScript;
    private AddRoom roomScript;
    private TransitionManager transitionManager;
    private Transition transitionInfo;

    // Start is called before the first frame update
    public void GenerateXMLFile()
    {

        // Create a new XML document
        XmlDocument xmlDoc = new XmlDocument();

        // Create the root element
        XmlElement rootElement = xmlDoc.CreateElement("map");
        xmlDoc.AppendChild(rootElement);

        // Create the layout element
        XmlElement layoutElement = xmlDoc.CreateElement("layout");
        rootElement.AppendChild(layoutElement);

        // Create the dungeons element
        XmlElement dungeonsElement = xmlDoc.CreateElement("dungeons");
        layoutElement.AppendChild(dungeonsElement);

        // Create room elements and add them to the dungeons element
        roomsScript = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        for (int i = 0; i < roomsScript.rooms.Count; i++) 
        {
            roomScript = roomsScript.rooms[i].GetComponent<AddRoom>();
            if(i == 0)
            {
                CreateRoomElement(xmlDoc, dungeonsElement, roomsScript.rooms[i].name, "Initial", roomScript.key);
            }
            else if(i == roomsScript.rooms.Count-1)
            {
                CreateRoomElement(xmlDoc, dungeonsElement, roomsScript.rooms[i].name, "Goal", roomScript.key);
            }
            else
            {
                CreateRoomElement(xmlDoc, dungeonsElement, roomsScript.rooms[i].name, "Intermedium", roomScript.key);
            }
        }

        // Create the transitions element
        XmlElement transitionsElement = xmlDoc.CreateElement("transitions");
        layoutElement.AppendChild(transitionsElement);

        // Create transition elements and add them to the transitions element
        transitionManager = GameObject.FindGameObjectWithTag("Rooms").GetComponent<TransitionManager>();
        for (int i = 0; i < transitionManager.totalTransitions.Count; i++) 
        {
            roomScript = roomsScript.rooms[i].GetComponent<AddRoom>();
            transitionInfo = transitionManager.totalTransitions[i].GetComponent<Transition>();
            CreateTransitionElement(xmlDoc, transitionsElement, transitionInfo.source, transitionInfo.destination, transitionInfo.bidirectional.ToString(), transitionInfo.keyNeeded);
        }
        

        // Save the XML document to a file
        string filePath = Application.dataPath + "/map.xml";
        xmlDoc.Save(filePath);

        Debug.Log("XML file generated at: " + filePath);
    }

    void CreateRoomElement(XmlDocument xmlDoc, XmlElement parentElement, string roomName, string state, string key)
    {
        XmlElement roomElement = xmlDoc.CreateElement("room");
        roomElement.SetAttribute("roomName", roomName);
        roomElement.SetAttribute("state", state);
        roomElement.SetAttribute("key", key);
        parentElement.AppendChild(roomElement);
    }

    void CreateTransitionElement(XmlDocument xmlDoc, XmlElement parentElement, string source, string destination, string bidirectional, string keyNeeded)
    {
        XmlElement transitionElement = xmlDoc.CreateElement("transition");
        transitionElement.SetAttribute("source", source);
        transitionElement.SetAttribute("destination", destination);
        transitionElement.SetAttribute("bidirectional", bidirectional);
        transitionElement.SetAttribute("keyNeeded", keyNeeded);
        parentElement.AppendChild(transitionElement);
    }
}
