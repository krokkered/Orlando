using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageNavigation : MonoBehaviour
{
    [SerializeField]
    GameObject page1;
    [SerializeField]
    GameObject page2;
    [SerializeField]
    GameObject page3;

    [SerializeField]
    GameObject[] pages;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextToPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);

    }
    public void NextToPage3()
    {
        page2.SetActive(false);
        page3.SetActive(true);
    }
    public void BackToPage2()
    {
        page3.SetActive(false);
        page2.SetActive(true);
    }
    public void BackToPage1()
    {
        page2.SetActive(false);
        page1.SetActive(true);
    }

    public void BackToPage(int p)
    {
        pages[p+1].SetActive(false);
        pages[p].SetActive(true);
    }

    public void NextToPage(int p)
    {
        pages[p+1].SetActive(false);
        pages[p+2].SetActive(true);
    }
}
