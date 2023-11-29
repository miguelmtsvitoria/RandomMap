using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public List<GameObject> totalTransitions;
    private RoomTemplates rooms;
    private Transition transitionInfoSource;
    private Transition transitionInfoDestination;
    private Transition lockTransitionAux;
    private Transition blockTransitionAux;
    private XMLGenerator xml;
    private PNMLGenerator pnml;
    private PNMLforLOLAGenerator lola;
    private float waitTime = 5f;
    private bool doOnce = true;
    private int rand;
    public GameObject Block;
     

    void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    void Update()
    {
        if(waitTime <= 0 && doOnce)
        {                
                DetectBlockedTransitions();
                Locktransitions();
                BlockDeadTransitions();
                RenameTransitions();
                xml = GameObject.FindGameObjectWithTag("Rooms").GetComponent<XMLGenerator>();
                xml.GenerateXMLFile();	
                pnml = GameObject.FindGameObjectWithTag("Rooms").GetComponent<PNMLGenerator>();
                pnml.GeneratePNMLFile();
                lola = GameObject.FindGameObjectWithTag("Rooms").GetComponent<PNMLforLOLAGenerator>();
                lola.GenerateLOLAFile();
                doOnce = false;		
		} 
        else 
        {
			waitTime -= Time.deltaTime;
		}

	}

    


    void DetectBlockedTransitions()
    {
        int totalCount = totalTransitions.Count;

        for (int i = 0; i < totalCount; i++) 
        {
            // Skip if this transition has already been processed
            if (totalTransitions[i] == null)
            {
                continue;
            }

            Transition transitionInfoSource = totalTransitions[i].GetComponent<Transition>();
            Vector3 sourcePosition = totalTransitions[i].transform.position;

            bool hasDuplicate = false;

            // Iterate through the remaining transitions
            for (int j = i + 1; j < totalCount; j++) 
            {
                if (totalTransitions[j] == null)
                {
                    continue;
                }

                Vector3 destinationPosition = totalTransitions[j].transform.position;

                if (sourcePosition == destinationPosition)
                {
                    Transition transitionInfoDestination = totalTransitions[j].GetComponent<Transition>();
                    transitionInfoSource.destination = transitionInfoDestination.source;
                    transitionInfoSource.blocked = false;

                    hasDuplicate = true;

                    Destroy(totalTransitions[j]);
                    totalTransitions[j] = null;
                }
            }

            if (!hasDuplicate)
            {
                transitionInfoSource.blocked = true;
            }
        }

        // Remove the destroyed transitions from the list
        totalTransitions.RemoveAll(transition => transition == null);
    }



	void RenameTransitions()
	{
		for (int k = 0; k < totalTransitions.Count; k++)
        {
            totalTransitions[k].gameObject.name = "Transition" + k;
        }
	}

    void Locktransitions()
    {
        for (int i = 0; i < (totalTransitions.Count / PlayerPrefs.GetFloat("Transitions")); i++) 
        {
            rand = Random.Range(0, totalTransitions.Count);
            lockTransitionAux = totalTransitions[rand].GetComponent<Transition>();
            lockTransitionAux.LockTransition();
        }
    }

    void BlockDeadTransitions()
    {
        for (int k = 0; k < totalTransitions.Count; k++)
        {
            blockTransitionAux = totalTransitions[k].GetComponent<Transition>();

            if(blockTransitionAux.blocked)
            {
                GameObject instantiatedObject = Instantiate(Block, totalTransitions[k].transform.position, totalTransitions[k].transform.rotation);
                Destroy(totalTransitions[k]);
                totalTransitions.Remove(totalTransitions[k]);
                Vector3 targetPosition = new Vector3(instantiatedObject.transform.position.x + 5 - 1.14f, instantiatedObject.transform.position.y + 8.3f, instantiatedObject.transform.position.z);
                instantiatedObject.transform.position = targetPosition;
                k = 0;

            }
        }
    }
}