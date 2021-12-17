using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    protected int CollectedItems = 0;
    [SerializeField]
    protected ScoreManager scoreManager;
    public AudioSource audioSource;
    public AudioClip pickedSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public virtual void addItem()
    {
        print("collezione normale");
        CollectedItems += 1;
        scoreManager.IncreaseScore();

        audioSource.PlayOneShot(pickedSound);

    }

    public int ItemsNumber()
    {
        return CollectedItems;
    }
}
