using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTransition : MonoBehaviour
{
    public TextMeshProUGUI textTransition;
    private Transition transition;

    // Update is called once per frame
    void Update()
    {
        transition = this.gameObject.GetComponent<Transition>();
        textTransition.text = transition.keyNeeded;
    }
}
