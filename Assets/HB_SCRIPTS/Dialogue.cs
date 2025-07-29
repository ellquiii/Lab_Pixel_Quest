using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string[] DialogueArray;
    public int DialogueIndex = 0;
    private TextMeshProUGUI _TextMeshPro;
    public Color[] textcolor;


    // Start is called before the first frame update
    void Start()
    {
        _TextMeshPro = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
        _TextMeshPro.text = DialogueArray[DialogueIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DialogueIndex++;
            if (DialogueIndex >= DialogueArray.Length)
            {
                DialogueIndex = 0;
            }
            _TextMeshPro.text = DialogueArray[DialogueIndex];
        }
    }
}