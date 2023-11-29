using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TransitionSpawner : MonoBehaviour
{
    public string originRoom;
    public GameObject transitionInst;
    private GameObject objectInstantiated;
    private TransitionManager transitionManager;
    private Transition transitionInfo;
    private bool doOnce = true;

    void Update()
    {
        if(doOnce)
        {
            objectInstantiated = Instantiate(transitionInst, transform.position, Quaternion.identity);
            transitionManager = GameObject.FindGameObjectWithTag("Rooms").GetComponent<TransitionManager>();
            transitionManager.totalTransitions.Add(objectInstantiated); 
            doOnce = false;
        }
        if(objectInstantiated != null)
        {
            transitionInfo = objectInstantiated.GetComponent<Transition>();
            transitionInfo.source = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.name;
        }
    }



    
}
