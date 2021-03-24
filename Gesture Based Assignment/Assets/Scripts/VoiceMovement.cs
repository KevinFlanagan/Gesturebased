using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;  //must have for StringBuilder
using System; //must have
using UnityEngine.Windows.Speech; //must have for grammar recogniser
using System.Linq; //must have
using System.IO;
using UnityEngine.SceneManagement;

public class VoiceMovement : MonoBehaviour
{

    private GrammarRecognizer gr;

    private string phrase = "";

    // Start is called before the first frame update
    void Start()
    {
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "Grammar.xml"), ConfidenceLevel.Low);
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        Debug.Log("Loaded grammar and recogniser started!");

    }


     private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
            {
                StringBuilder message = new StringBuilder();
                Debug.Log("Picked up a phrase");
                var meanings = args.semanticMeanings;

                foreach(SemanticMeaning meaning in meanings)
                {
                 string keyString = meaning.key.Trim();
                 string valueString = meaning.values[0].Trim();
                 message.Append("Key:  " + keyString + ", Value: " + valueString);
                phrase = valueString;
                }
        //using string builder to output the sting to the user
        Debug.Log(message);
 }

    void Update()
    {
        //Call upon the functions
        switch (phrase)
        {
            
            case "forward":
                Forward();
                break;
            case "backward":
                Backward();
                break;
            case "left":
                Left();
                break;
            case "right":
                Right();
                break;

        }
    }
    // Controls for cube
    private void Forward()
    {
        transform.Translate(1,0,0);
    }
    private void Backward()
    {
        transform.Translate(-1,0,0);
    }

    private void Left()
    {
        transform.Translate(0,0,0);
    }

    private void Right()
    {
        transform.Translate(0,-1,0);
    }
    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }

}
