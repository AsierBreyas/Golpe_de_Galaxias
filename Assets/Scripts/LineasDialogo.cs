using TMPro;
using UnityEngine;

public class LineasDialogo : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;
    int currentLineIndex;
    public void DisplayNextLine()
    {
        currentLineIndex++;
        dialogueText.text = timelineTextLines[currentLineIndex];
    }
}
