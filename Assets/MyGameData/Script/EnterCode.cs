using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterCode : MonoBehaviour
{
    [SerializeField] private Button _submit;
    [SerializeField] private Button _goBack;
    [SerializeField] private InputField _playerCode;
    private string rightCode;
    


    void Start()
    {
        rightCode = "4MAY";
        Button btn = _submit.GetComponent<Button>();
        btn.onClick.AddListener(Overload);
    }

    

    void Overload()
    {
        if (_playerCode.text == rightCode)
        {
            Core.isOverloaded = true;
            _playerCode.image.color = Color.green;
            var timer = 0;
            var time = 3;
            while (timer < time)
            {
                timer += 1;
            }
            gameObject.SetActive(false);
        }
        else
        {
            _playerCode.image.color = Color.red;
        }
    }
    
}
