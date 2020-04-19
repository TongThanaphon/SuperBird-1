using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(delegate{UnityEngine.SceneManagement.SceneManager.LoadScene("Landing", LoadSceneMode.Single);});
    }
}
