using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    protected enum State
    {
        Alive,
        Killable,
        Dead,
        Warned,
        WarnedClose
    }


    public bool isAlive = true;

    [SerializeField]
    protected State soldierState = State.Alive;

    protected GameObject childSword;
    protected GameObject childBlood;
    // Start is called before the first frame update
    protected void Start()
    {
        childSword = gameObject.transform.Find("sword").gameObject;
        childBlood = gameObject.transform.Find("macchiadisangue").gameObject;

    }

    // Update is called once per frame
    protected void Update()
    {

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {

            if (soldierState == State.Killable)
            {
                this.killed();

            }
            else if (soldierState == State.WarnedClose)
            {
                print("Oh no, hai svegliato il soldato!");
                //partita persa, si riparte dal cicpoint
            }
        }


    }



    public void killed()
    {
        if (soldierState == State.Killable)
        {
            isAlive=false;
            soldierState = State.Dead;

            SpriteRenderer soldatoSprite = GetComponent<SpriteRenderer>();
            soldatoSprite.enabled = false;

            childSword.SetActive(false);
            childBlood.SetActive(true);

        }

    }

    public void setWarned()
    {

        soldierState = State.Warned;
    }

    public void setAlive()
    {
        soldierState = State.Alive;

    }
    public void setKillable()
    {
        soldierState = State.Killable;

    }


    public bool getWarned()
    {

        if (soldierState == State.Warned || soldierState == State.WarnedClose)
        {
            return true;
        }
        return false;
    }
    public bool getKillable()
    {

        if (soldierState == State.Killable)
        {
            return true;
        }
        return false;
    }

    public bool getAlive()
    {

        if (soldierState == State.Alive)
        {
            return true;
        }
        return false;
    }

    public void showSword()
    {

        childSword.SetActive(true);
    }

    public void hideSword()
    {
        childSword.SetActive(false);

    }

}
