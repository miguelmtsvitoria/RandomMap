using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;



public class PNMLforLOLAGenerator : MonoBehaviour
{
    private int currentID = 1;
    private int currentX = 100;
    private int currentY = 100;
    public List<RoomData> roomList = new List<RoomData>();

    public void GenerateLOLAFile()
    {
        // Create an XmlDocument
        XmlDocument doc = new XmlDocument();

        // Create the XML declaration
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

        // Add the XML declaration to the document
        doc.AppendChild(xmlDeclaration);

        // Create the <pnml> element with the "xmlns" attribute
        XmlElement pnmlElement = doc.CreateElement("pnml", "http://www.pnml.org/version-2009/grammar/pnml");

        // Create the <net> element without specifying a namespace prefix
        XmlElement netElement = doc.CreateElement("net");

        // Set the "type" attribute
        XmlAttribute typeAttribute = doc.CreateAttribute("type");
        typeAttribute.Value = "http://www.pnml.org/version-2009/grammar/ptnet";
        netElement.Attributes.Append(typeAttribute);

        // Set the "id" attribute
        XmlAttribute idAttribute = doc.CreateAttribute("id");
        idAttribute.Value = "PGCD-PT-D02N005";
        netElement.Attributes.Append(idAttribute);

        // Append the <net> element to the <pnml> element
        pnmlElement.AppendChild(netElement);

        // Append the <pnml> element to the XmlDocument
        doc.AppendChild(pnmlElement);

        XmlElement nameElement = doc.CreateElement("name");
        netElement.AppendChild(nameElement);

        XmlElement textElement = doc.CreateElement("text");
        textElement.InnerText = "ZZZZZZ";
        nameElement.AppendChild(textElement);

        XmlElement pageElement = doc.CreateElement("page");
        netElement.AppendChild(pageElement);

        XmlElement idElement = doc.CreateElement("id");
        idElement.SetAttribute("id", "page");
        pageElement.AppendChild(idElement);

        


        void CreatePlace(XmlElement parentElement, string id, string name, int x, int y, int initialMarking)
        {
            XmlElement placeElement = doc.CreateElement("place");
            placeElement.SetAttribute("id", "p" + id);
            parentElement.AppendChild(placeElement);

            // <name> element
            XmlElement nameElement = doc.CreateElement("name");
            placeElement.AppendChild(nameElement);

            XmlElement textElement = doc.CreateElement("text");
            textElement.InnerText = "p" + name;
            nameElement.AppendChild(textElement);

            // <initialMarking> element
            XmlElement initialMarkingElement = doc.CreateElement("initialMarking");
            placeElement.AppendChild(initialMarkingElement);

            XmlElement initialMarkingTextElement = doc.CreateElement("text");
            initialMarkingTextElement.InnerText = initialMarking.ToString();
            initialMarkingElement.AppendChild(initialMarkingTextElement);
        }

        void CreateTransition(XmlElement parentElement, string id, string name, int x, int y, int priority)
        {
            XmlElement transitionElement = doc.CreateElement("transition");
            transitionElement.SetAttribute("id", "t" + id);
            parentElement.AppendChild(transitionElement);

            // <name> element
            XmlElement nameElement = doc.CreateElement("name");
            transitionElement.AppendChild(nameElement);

            XmlElement textElement = doc.CreateElement("text");
            textElement.InnerText = name;
            nameElement.AppendChild(textElement);
        }

        void CreateArc(XmlElement parentElement, string id, string source, string target, string inscriptionValue, int xOffset, int yOffset)
        {
            XmlElement arcElement = doc.CreateElement("arc");
            arcElement.SetAttribute("id", "a" + id);
            arcElement.SetAttribute("source", source);
            arcElement.SetAttribute("target", target);
            parentElement.AppendChild(arcElement);

        }

        string path = Application.dataPath + "/map.xml";
        string xmlText = System.IO.File.ReadAllText(path); 
        // Create a new XmlDocument instance and load the XML content
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlText);

        // Get the dungeons element
        XmlNode dungeonsNode = xmlDoc.SelectSingleNode("/map/layout/dungeons");
        // Get the transitions element
        XmlNode transitionsNode = xmlDoc.SelectSingleNode("/map/layout/transitions");

        if (dungeonsNode != null)
        {
            // Iterate through each room element
            foreach (XmlNode roomNode in dungeonsNode.ChildNodes)
            {
                string roomName = roomNode.Attributes["roomName"].Value;
                string state = roomNode.Attributes["state"].Value;
                string key = roomNode.Attributes["key"].Value;

                if(state == "Initial")
                {
                    CreatePlace(pageElement, currentID.ToString(), roomName, currentX, currentY, 1);
                    currentY = currentY + 80;
                    RoomData initialRoom = new RoomData();
                    initialRoom.id = currentID;
                    initialRoom.name = roomName;
                    roomList.Add(initialRoom);
                    currentID++;
                }
                else if(key != "")
                {
                    CreatePlace(pageElement, currentID.ToString(), roomName, currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData room = new RoomData();
                    room.id = currentID;
                    room.name = roomName;
                    roomList.Add(room);
                    currentID++;

                    CreatePlace(pageElement, currentID.ToString(), key, currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData roomKey = new RoomData();
                    roomKey.id = currentID;
                    roomKey.name = key;
                    roomList.Add(roomKey);
                    currentID++;

                    CreatePlace(pageElement, currentID.ToString(), key + "_exists", currentX, currentY, 1);
                    currentX = currentX + 50;
                    RoomData roomKey_exists = new RoomData();
                    roomKey_exists.id = currentID;
                    roomKey_exists.name = key + "_exists";
                    roomList.Add(roomKey_exists);
                    currentID++;

                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(pageElement, currentID.ToString(), "p" + (currentID-4).ToString(), "t" + (currentID-1).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-2).ToString(), "p" + (currentID-5).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + (currentID-4).ToString(), "t" + (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-4).ToString(), "p" + (currentID-6).ToString(), "1", -5, 12);
                    currentID++;

                }
                else
                {
                    CreatePlace(pageElement, currentID.ToString(), roomName, currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData simpleRoom = new RoomData();
                    simpleRoom.id = currentID;
                    simpleRoom.name = roomName;
                    roomList.Add(simpleRoom);
                    currentID++;
                }
            }
            currentX = 100;
            currentY = currentY + 80;
        }

        if (transitionsNode != null)
        {
            // Iterate through each room element
            foreach (XmlNode transNode in transitionsNode.ChildNodes)
            {
                string source = transNode.Attributes["source"].Value;
                string destination = transNode.Attributes["destination"].Value;
                string bidirectional = transNode.Attributes["bidirectional"].Value;
                string keyNeeded = transNode.Attributes["keyNeeded"].Value;

                if(bidirectional == "False" && keyNeeded == "")
                {
                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(source).ToString(), "t" + (currentID-1).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-2).ToString(), "p" + GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                }
                else if(bidirectional == "True" && keyNeeded == "")
                {
                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(source).ToString(), "t" + (currentID-2).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-3).ToString(), "p" + GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(destination).ToString(), "t" + (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-4).ToString(), "p" + GetRoomIDByName(source).ToString(), "1", -5, 12);
                    currentID++;
                }

                else if(bidirectional == "False" && keyNeeded != "")
                {
                    CreatePlace(pageElement, currentID.ToString(), keyNeeded + "_locked", currentX, currentY, 1);
                    currentX = currentX + 50;
                    RoomData roomLocked = new RoomData();
                    roomLocked.id = currentID;
                    roomLocked.name = keyNeeded + "_locked";
                    roomList.Add(roomLocked);
                    currentID++;
                    CreatePlace(pageElement, currentID.ToString(), keyNeeded + "_unlocked", currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData roomUnlocked = new RoomData();
                    roomUnlocked.id = currentID;
                    roomUnlocked.name = keyNeeded + "_unlocked";
                    roomList.Add(roomUnlocked);
                    currentID++;
                    
                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(keyNeeded).ToString(), "t" + (currentID-2).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(keyNeeded + "_locked").ToString(), "t" + (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(source).ToString(), "t" + (currentID-4).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-5).ToString(), "p" + GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-6).ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(source).ToString(), "t" + (currentID-6).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-7).ToString(), "p" + GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-8).ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "t" + (currentID-9).ToString(), "1", -5, 12);
                    currentID++;
                }
                else if(bidirectional == "True" && keyNeeded != "")
                {
                    CreatePlace(pageElement, currentID.ToString(), keyNeeded + "_locked", currentX, currentY, 1);
                    currentX = currentX + 50;
                    RoomData roomLockedBidirectional = new RoomData();
                    roomLockedBidirectional.id = currentID;
                    roomLockedBidirectional.name = keyNeeded + "_locked";
                    roomList.Add(roomLockedBidirectional);
                    currentID++;
                    CreatePlace(pageElement, currentID.ToString(), keyNeeded + "_unlocked", currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData roomUnlockedBidirectional = new RoomData();
                    roomUnlockedBidirectional.id = currentID;
                    roomUnlockedBidirectional.name = keyNeeded + "_unlocked";
                    roomList.Add(roomUnlockedBidirectional);
                    currentID++;

                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(pageElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(keyNeeded).ToString(), "t" + (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(keyNeeded + "_locked").ToString(), "t" + (currentID-4).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(source).ToString(), "t" + (currentID-5).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-6).ToString(), "p" + GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-7).ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(source).ToString(), "t" + (currentID-7).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-8).ToString(), "p" + GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-9).ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "t" + (currentID-10).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "t" + (currentID-10).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-11).ToString(), "p" + GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "t" + (currentID-12).ToString(), "p" + GetRoomIDByName(source).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(pageElement, currentID.ToString(), "p" + GetRoomIDByName(destination).ToString(), "t" + (currentID-13).ToString(), "1", -5, 12);
                    currentID++;
                    
                }
            }
        }


        // Save the document to a file
        string filePath = Application.dataPath + "/map_lola.pnml";
        doc.Save(filePath);
        Debug.Log("PNML file generated at: " + filePath);

    }


    private int GetRoomIDByName(string roomName)
    {
        RoomData room = roomList.Find(x => x.name == roomName);

        if (room != null)
        {
            return room.id;
        }
        else
        {
            return -1; // Return -1 to indicate the room was not found
        }
    }

    
}
