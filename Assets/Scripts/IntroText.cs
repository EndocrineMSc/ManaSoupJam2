using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DreamCatcher;
using EnumCollection;
using Unity.VisualScripting;

public class IntroText : MonoBehaviour
{
    #region Fields

    [SerializeField] private TextMeshProUGUI _introText;

    private readonly string _text1 = "As usual, it is darkest night when you receive your assignment. There aren't many details, but apparently it's a weird ritual gone wrong.";
    private readonly string _text2 = "The result: Some teenagers at a far-out camp in the woods contracted \"Manifestion Nightmare Disorder\".";
    private readonly string _text3 = "It is your duty as guardian of deep dreams to rid the teenagers of their curse and make the woods safe again.";
    private readonly string _text4 = "Unfortunately, those afflicted tend to wander in their sleep until they have found a remote location in which their nightmares can cross over to reality!";
    private readonly string _text5 = "Find the sleepers, destroy the nightmares and save the night!";

    private List<char> _charList = new List<char>();
    private string[] _introTexts;
    private string _tempText;

    private int _currentText = 0;
    private bool keyDown;

    #endregion


    private void Awake()
    {
        _introTexts = new string[] { _text1, _text2, _text3, _text4, _text5 };
    }

    // Start is called before the first frame update
    void Start()
    {      
        ReturnCharList(_text1);
        StartCoroutine(PrintSlow());
        _currentText++;
    }


    private void Update()
    {
        if (Input.anyKeyDown)
        {           
            keyDown = true;
            _tempText = "";
            _charList.Clear();
            keyDown = false;
            PrintIntroText();    
        }

        _introText.text = _tempText;
    }

    private void PrintIntroText()
    {
        if (_currentText < _introTexts.Length)
        {
            string temp = _introTexts[_currentText];
            ReturnCharList(temp);
            StartCoroutine(PrintSlow());
            _currentText++;
        }
        else
        {
            StopAllCoroutines();
            GameManager.Instance.SwitchState(GameState.Starting);
        }       
    }

    private void ReturnCharList(string text)
    {
        foreach (char c in text)
        {
            _charList.Add(c);
        }
    }

    private IEnumerator PrintSlow()
    {
        foreach (char c in _charList)
        {
            _tempText += c;
            yield return new WaitForSeconds(0.02f);

            if (keyDown)
            {
                _tempText = "";
                StopAllCoroutines();
            }
        }
    }
}
