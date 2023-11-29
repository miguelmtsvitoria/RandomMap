using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

[System.Serializable] // This attribute allows Unity to show the class in the Inspector
public class RoomData
{
    public int id;
    public string name;
}

public class PNMLGenerator : MonoBehaviour
{
    private int currentID = 1;
    private int currentX = 100;
    private int currentY = 100;
    public List<RoomData> roomList = new List<RoomData>();

    public void GeneratePNMLFile()
    {
        // Create XML document
        XmlDocument doc = new XmlDocument();

        // XML declaration
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "iso-8859-1", "no");
        doc.AppendChild(xmlDeclaration);

        // Root element <Snoopy>
        XmlElement rootElement = doc.CreateElement("Snoopy");
        rootElement.SetAttribute("revision", "0");
        rootElement.SetAttribute("version", "0");
        doc.AppendChild(rootElement);

        // <pnml> element
        XmlElement pnmlElement = doc.CreateElement("pnml");
        rootElement.AppendChild(pnmlElement);

        // <net> element
        XmlElement netElement = doc.CreateElement("net");
        netElement.SetAttribute("id", currentID.ToString());
        currentID++;
        netElement.SetAttribute("name", "map3");
        netElement.SetAttribute("type", "IOPT");
        pnmlElement.AppendChild(netElement);

        // <input>, <output>, and <variable> elements
        netElement.AppendChild(doc.CreateElement("input"));
        netElement.AppendChild(doc.CreateElement("output"));
        netElement.AppendChild(doc.CreateElement("variable"));

        void CreatePlace(XmlElement parentElement, string id, string name, int x, int y, int initialMarking)
        {
            XmlElement placeElement = doc.CreateElement("place");
            placeElement.SetAttribute("id", id);
            parentElement.AppendChild(placeElement);

            // <name> element
            XmlElement nameElement = doc.CreateElement("name");
            placeElement.AppendChild(nameElement);

            XmlElement textElement = doc.CreateElement("text");
            textElement.InnerText = name;
            nameElement.AppendChild(textElement);

            XmlElement nameGraphicsElement = doc.CreateElement("graphics");
            nameElement.AppendChild(nameGraphicsElement);

            XmlElement nameOffsetElement = doc.CreateElement("offset");
            nameOffsetElement.SetAttribute("x", "-10");
            nameOffsetElement.SetAttribute("y", "20");
            nameGraphicsElement.AppendChild(nameOffsetElement);

            // <comment> element
            XmlElement commentElement = doc.CreateElement("comment");
            placeElement.AppendChild(commentElement);

            XmlElement commentGraphicsElement = doc.CreateElement("graphics");
            commentElement.AppendChild(commentGraphicsElement);

            XmlElement commentOffsetElement = doc.CreateElement("offset");
            commentOffsetElement.SetAttribute("x", "-30");
            commentOffsetElement.SetAttribute("y", "20");
            commentGraphicsElement.AppendChild(commentOffsetElement);

            // <initialMarking> element
            XmlElement initialMarkingElement = doc.CreateElement("initialMarking");
            placeElement.AppendChild(initialMarkingElement);

            XmlElement initialMarkingTextElement = doc.CreateElement("text");
            initialMarkingTextElement.InnerText = initialMarking.ToString();
            initialMarkingElement.AppendChild(initialMarkingTextElement);

            XmlElement initialMarkingGraphicsElement = doc.CreateElement("graphics");
            initialMarkingElement.AppendChild(initialMarkingGraphicsElement);

            XmlElement initialMarkingOffsetElement = doc.CreateElement("offset");
            initialMarkingOffsetElement.SetAttribute("x", "0");
            initialMarkingOffsetElement.SetAttribute("y", "-1");
            initialMarkingGraphicsElement.AppendChild(initialMarkingOffsetElement);

            // <bound> element
            XmlElement boundElement = doc.CreateElement("bound");
            placeElement.AppendChild(boundElement);

            XmlElement boundTextElement = doc.CreateElement("text");
            boundTextElement.InnerText = "3";
            boundElement.AppendChild(boundTextElement);

            // <graphics> element
            XmlElement graphicsElement = doc.CreateElement("graphics");
            placeElement.AppendChild(graphicsElement);

            XmlElement positionElement = doc.CreateElement("position");
            //positionElement.SetAttribute("page", "1");
            //positionElement.SetAttribute("x", x.ToString());
            //positionElement.SetAttribute("y", y.ToString());
            graphicsElement.AppendChild(positionElement);
        }

        void CreateTransition(XmlElement parentElement, string id, string name, int x, int y, int priority)
        {
            XmlElement transitionElement = doc.CreateElement("transition");
            transitionElement.SetAttribute("id", id);
            parentElement.AppendChild(transitionElement);

            // <name> element
            XmlElement nameElement = doc.CreateElement("name");
            transitionElement.AppendChild(nameElement);

            XmlElement textElement = doc.CreateElement("text");
            textElement.InnerText = name;
            nameElement.AppendChild(textElement);

            XmlElement nameGraphicsElement = doc.CreateElement("graphics");
            nameElement.AppendChild(nameGraphicsElement);

            XmlElement nameOffsetElement = doc.CreateElement("offset");
            nameOffsetElement.SetAttribute("x", "-10");
            nameOffsetElement.SetAttribute("y", "20");
            nameGraphicsElement.AppendChild(nameOffsetElement);

            // <comment> element
            XmlElement commentElement = doc.CreateElement("comment");
            transitionElement.AppendChild(commentElement);

            XmlElement commentGraphicsElement = doc.CreateElement("graphics");
            commentElement.AppendChild(commentGraphicsElement);

            XmlElement commentOffsetElement = doc.CreateElement("offset");
            commentOffsetElement.SetAttribute("x", "-30");
            commentOffsetElement.SetAttribute("y", "20");
            commentGraphicsElement.AppendChild(commentOffsetElement);

            // <priority> element
            XmlElement priorityElement = doc.CreateElement("priority");
            priorityElement.InnerText = priority.ToString();
            transitionElement.AppendChild(priorityElement);

            // <graphics> element
            XmlElement graphicsElement = doc.CreateElement("graphics");
            transitionElement.AppendChild(graphicsElement);

            XmlElement positionElement = doc.CreateElement("position");
            //positionElement.SetAttribute("page", "1");
            //positionElement.SetAttribute("x", x.ToString());
            //positionElement.SetAttribute("y", y.ToString());
            graphicsElement.AppendChild(positionElement);

            // <inputEvents> and <outputEvents> elements
            transitionElement.AppendChild(doc.CreateElement("inputEvents"));
            transitionElement.AppendChild(doc.CreateElement("outputEvents"));
        }

        void CreateArc(XmlElement parentElement, string id, string source, string target, string inscriptionValue, int xOffset, int yOffset)
        {
            XmlElement arcElement = doc.CreateElement("arc");
            arcElement.SetAttribute("id", id);
            arcElement.SetAttribute("source", source);
            arcElement.SetAttribute("target", target);
            parentElement.AppendChild(arcElement);

            // <type> element
            XmlElement typeElement = doc.CreateElement("type");
            typeElement.InnerText = "normal";
            arcElement.AppendChild(typeElement);

            // <inscription> element
            XmlElement inscriptionElement = doc.CreateElement("inscription");
            arcElement.AppendChild(inscriptionElement);

            XmlElement inscriptionGraphicsElement = doc.CreateElement("graphics");
            inscriptionElement.AppendChild(inscriptionGraphicsElement);

            XmlElement inscriptionOffsetElement = doc.CreateElement("offset");
            inscriptionOffsetElement.SetAttribute("page", "1");
            inscriptionOffsetElement.SetAttribute("x", xOffset.ToString());
            inscriptionOffsetElement.SetAttribute("y", yOffset.ToString());
            inscriptionGraphicsElement.AppendChild(inscriptionOffsetElement);

            XmlElement valueElement = doc.CreateElement("value");
            valueElement.InnerText = inscriptionValue;
            inscriptionElement.AppendChild(valueElement);

            // <graphics> element
            arcElement.AppendChild(doc.CreateElement("graphics"));
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
                    CreatePlace(netElement, currentID.ToString(), roomName, currentX, currentY, 1);
                    currentY = currentY + 80;
                    RoomData initialRoom = new RoomData();
                    initialRoom.id = currentID;
                    initialRoom.name = roomName;
                    roomList.Add(initialRoom);
                    currentID++;
                }
                else if(key != "")
                {
                    CreatePlace(netElement, currentID.ToString(), roomName, currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData room = new RoomData();
                    room.id = currentID;
                    room.name = roomName;
                    roomList.Add(room);
                    currentID++;

                    CreatePlace(netElement, currentID.ToString(), key, currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData roomKey = new RoomData();
                    roomKey.id = currentID;
                    roomKey.name = key;
                    roomList.Add(roomKey);
                    currentID++;

                    CreatePlace(netElement, currentID.ToString(), key + "_exists", currentX, currentY, 1);
                    currentX = currentX + 50;
                    RoomData roomKey_exists = new RoomData();
                    roomKey_exists.id = currentID;
                    roomKey_exists.name = key + "_exists";
                    roomList.Add(roomKey_exists);
                    currentID++;

                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(netElement, currentID.ToString(), (currentID-4).ToString(), (currentID-1).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-2).ToString(), (currentID-5).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-4).ToString(), (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-4).ToString(), (currentID-6).ToString(), "1", -5, 12);
                    currentID++;

                }
                else
                {
                    CreatePlace(netElement, currentID.ToString(), roomName, currentX, currentY, 0);
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
                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(source).ToString(), (currentID-1).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-2).ToString(), GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                }
                else if(bidirectional == "True" && keyNeeded == "")
                {
                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(source).ToString(), (currentID-2).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-3).ToString(), GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(destination).ToString(), (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-4).ToString(), GetRoomIDByName(source).ToString(), "1", -5, 12);
                    currentID++;
                }

                else if(bidirectional == "False" && keyNeeded != "")
                {
                    CreatePlace(netElement, currentID.ToString(), keyNeeded + "_locked", currentX, currentY, 1);
                    currentX = currentX + 50;
                    RoomData roomLocked = new RoomData();
                    roomLocked.id = currentID;
                    roomLocked.name = keyNeeded + "_locked";
                    roomList.Add(roomLocked);
                    currentID++;
                    CreatePlace(netElement, currentID.ToString(), keyNeeded + "_unlocked", currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData roomUnlocked = new RoomData();
                    roomUnlocked.id = currentID;
                    roomUnlocked.name = keyNeeded + "_unlocked";
                    roomList.Add(roomUnlocked);
                    currentID++;
                    
                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;

                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(keyNeeded).ToString(), (currentID-2).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(keyNeeded + "_locked").ToString(), (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(source).ToString(), (currentID-4).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-5).ToString(), GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-6).ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(source).ToString(), (currentID-6).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-7).ToString(), GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-8).ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), (currentID-9).ToString(), "1", -5, 12);
                    currentID++;
                }
                else if(bidirectional == "True" && keyNeeded != "")
                {
                    CreatePlace(netElement, currentID.ToString(), keyNeeded + "_locked", currentX, currentY, 1);
                    currentX = currentX + 50;
                    RoomData roomLockedBidirectional = new RoomData();
                    roomLockedBidirectional.id = currentID;
                    roomLockedBidirectional.name = keyNeeded + "_locked";
                    roomList.Add(roomLockedBidirectional);
                    currentID++;
                    CreatePlace(netElement, currentID.ToString(), keyNeeded + "_unlocked", currentX, currentY, 0);
                    currentX = currentX + 50;
                    RoomData roomUnlockedBidirectional = new RoomData();
                    roomUnlockedBidirectional.id = currentID;
                    roomUnlockedBidirectional.name = keyNeeded + "_unlocked";
                    roomList.Add(roomUnlockedBidirectional);
                    currentID++;

                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    CreateTransition(netElement, currentID.ToString(), "t" + currentID, currentX, currentY, 1);
                    currentX = currentX + 50;
                    currentID++;
                    
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(keyNeeded).ToString(), (currentID-3).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(keyNeeded + "_locked").ToString(), (currentID-4).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(source).ToString(), (currentID-5).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-6).ToString(), GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-7).ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(source).ToString(), (currentID-7).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-8).ToString(), GetRoomIDByName(destination).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-9).ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), (currentID-10).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), (currentID-10).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-11).ToString(), GetRoomIDByName(keyNeeded + "_unlocked").ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), (currentID-12).ToString(), GetRoomIDByName(source).ToString(), "1", -5, 12);
                    currentID++;
                    CreateArc(netElement, currentID.ToString(), GetRoomIDByName(destination).ToString(), (currentID-13).ToString(), "1", -5, 12);
                    currentID++;
                    
                }
            }
        }


        // Save the document to a file
        string filePath = Application.dataPath + "/map_iopt.pnml";
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
