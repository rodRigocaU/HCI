using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceControler2 : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();


    void Start()
    {
        keywords.Add("forward", Forward);
        keywords.Add("up", Up);
        keywords.Add("down", Down);
        keywords.Add("back", Back);
        keywords.Add("cuche", Cuche);
        Debug.Log("FUNCA HASTA AQUI2");

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        Debug.Log("FUNCA HASTA AQUI3");
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        Debug.Log("FUNCA HASTA AQUI4");
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("FUNCA HASTA AQUI5");
        Debug.Log(args.text);

        keywords[args.text].Invoke();
       /* System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }*/
    }
    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }

    private void Up()
    {
        transform.Translate(0, 1, 0);
    }
    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }
    private void Down()
    {
        transform.Translate(0, -1, 0);
    }

    private void Cuche()
    {
        transform.localScale(0.01f, 0.01f, 0.01f);
    }
}
