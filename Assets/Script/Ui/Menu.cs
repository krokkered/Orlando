using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{



    public void GoToLevel1()
    {
        SceneManager.LoadScene("Bosco");

    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Bosco2");

    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Bosco3");

    }

}
