using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] DialogueArray;
    public int DialogueIndex = 0;
    private TextMeshProUGUI _TextMeshPro;
    public Color[] textColor;
    private bool isTyping = false;
    public float amountTime; // Adjust this to control the speed of typing effect

    // Start is called before the first frame update
    void Start()
    {
        if (DialogueArray.Length > 0)
        {
            _TextMeshPro = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
            StartCoroutine(DisplayDialogue());
        }
        else
        {
            Debug.LogWarning("DialogueArray is empty!");
        }
    }

    // Coroutine to handle the letter-by-letter typing effect
    IEnumerator DisplayDialogue()
    {
        isTyping = true;

        // Ensure we don't go out of bounds for DialogueArray or textColor
        if (DialogueIndex < DialogueArray.Length && DialogueIndex < textColor.Length)
        {
            _TextMeshPro.text = ""; // Clear the current text
            _TextMeshPro.color = textColor[DialogueIndex]; // Set the appropriate color

            string currentDialogue = DialogueArray[DialogueIndex];

            for (int i = 0; i < currentDialogue.Length; i++)
            {
                _TextMeshPro.text += currentDialogue[i]; // Add one character at a time
                yield return new WaitForSeconds(amountTime); // Wait before showing the next character
            }
        }
        else
        {
            Debug.LogWarning("DialogueIndex or textColor array is out of bounds!");
        }

        isTyping = false; // Allow skipping when typing is done
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isTyping)
        {
            DialogueIndex++;
            if (DialogueIndex >= DialogueArray.Length) // Prevent going out of bounds
            {
                DialogueIndex = 0; // Loop back to the first dialogue
            }
            StartCoroutine(DisplayDialogue()); // Start displaying the next dialogue
        }
    }
}
