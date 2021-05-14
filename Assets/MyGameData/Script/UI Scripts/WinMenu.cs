using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    
    [SerializeField] private Button _toMenu;
    private void Awake()
    {

       
        _toMenu.onClick.AddListener(ToMenu);

    }

   
    void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
