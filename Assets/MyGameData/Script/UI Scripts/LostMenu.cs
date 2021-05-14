using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    [SerializeField] private Button _reload;
    [SerializeField] private Button _toMenu;
    private void Awake()
    {

        _reload.onClick.AddListener(Reload);
        _toMenu.onClick.AddListener(ToMenu);
       
    }

    void Reload()
    {
        SceneManager.LoadScene(1);
    }
    void ToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
