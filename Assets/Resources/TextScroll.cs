using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScroll : MonoBehaviour
{

    private TextMeshProUGUI textComponent;

    [SerializeField]
    private float characterDelay = 0.03f;

    [SerializeField]
    private float delayBeforeStarting = 0f;

    //[HideInInspector]
    public bool finished = false;

    [SerializeField]
    private bool skippable = true;

    [SerializeField]
    private bool isDependant = false;

    [SerializeField]
    private GameObject dependantObject = null;

    [SerializeField]
    private bool shouldOnlyRunOnCall = false;

    private TextScroll dependant = null;

    private bool called = false;

    bool run = false;
    
    int visibleCount = 0;

    KeyCode[] skipKeys = {KeyCode.Mouse1, KeyCode.Space};

    private int maxCharacters = 1000;


    void Start()
    {
        InitializeComponents();

    }

    void InitializeComponents()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        textComponent.maxVisibleCharacters = 0;
        

        if (isDependant)
        {
            dependant = dependantObject.GetComponent<TextScroll>();
        }
    }

    void Update()
    {
        // The text will start scrolling into visibility...
        bool ready = true;

        // Unless it should only be run when called to run...
        if (shouldOnlyRunOnCall)
        {
            if (!called)
            {
                ready = false;
            }
        }

        // Or if it is dependant on another text box to finish first...
        if (isDependant)
        {
            if (!dependant.finished)
            {
                ready = false;
            }
            else if (dependant.finished)
            {
                if (run)
                {
                    ready = false;
                }
            }
        }

        // Or it has already scrolled...
        if (run)
        {
            ready = false;
        }

        // If it is still ready, it runs (and marks itself that is has run)
        if (ready)
        {
            StartCoroutine(ScrollText());
            run = true;
        }

        // If the text is skippable, check to see if any of the skip keys were pressed
        if (skippable)
        {   //checks all keys in the skipKeys KeyCode array - if any of them are     vvvvvvv     then it proceeds to...
            for (int keyIndex = 0; keyIndex < skipKeys.Length; keyIndex++) if (Input.GetKeyUp(skipKeys[keyIndex]))
            {
                SkipText();
            }
        }
    }

    public void SkipText()
    {
        textComponent.maxVisibleCharacters = maxCharacters;
        visibleCount = maxCharacters;
        finished = true;
    }


    // Remember to StartCoroutine(ScrollText()); You cannot call IEnumerator as a regular function.
    public IEnumerator ScrollText()
    {
        return ScrollText(delayBeforeStarting);
    }
    public IEnumerator ScrollText(float delay)
    {
        yield return new WaitForSeconds(delay);

        StartCoroutine(actuallyScrollText());
    }
    
    private IEnumerator actuallyScrollText()
    {
        while (true)
        {
            visibleCount++;
            textComponent.maxVisibleCharacters = visibleCount;

            if (visibleCount >= textComponent.textInfo.characterCount)
            {
                finished = true;
                textComponent.maxVisibleCharacters = maxCharacters;
                break;
            }
            else
            {
                yield return new WaitForSeconds(characterDelay);
            }
        }

    }

    public void ScrollNewText()
    {
        StopAllCoroutines();
        finished = false;
        called = true;
        run = false;
        visibleCount = 0;
        textComponent.maxVisibleCharacters = 0;
    }

}

