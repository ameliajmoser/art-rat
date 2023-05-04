using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPrompt : MonoBehaviour
{
    [SerializeField]
    public Text promptText;

    [SerializeField]
    public string[] prompts;

    System.Random random = new System.Random();

    public void NewPrompt(){
        promptText.text = prompts[random.Next(prompts.Length)];;    
    }
     
}
