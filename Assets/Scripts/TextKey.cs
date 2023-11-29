using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextKey : MonoBehaviour
{
    public TextMeshProUGUI textKey;
    private AddRoom room;

    void Update()
    {
        room = this.gameObject.GetComponent<AddRoom>();
        textKey.text = room.key;
    }
}
