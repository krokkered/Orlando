using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockTextTrigger : MonoBehaviour
{
    public RectTransform BlurImageRef;
    public ScrollRect scrollRect;
    public Text textRef;
    bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Rigidbody2D rbody = other.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null && rbody.tag == "Player")
        {

            //scrollRect.verticalNormalizedPosition = 0.126f;
            if (!unlocked)
            {
                unlocked = true;
                StartCoroutine(LerpPositionAndFadeText(0.126f, 2));
            }
        }
    }


    IEnumerator LerpPositionAndFadeText(float position, float duration)
    {
        float time = 0;
        float startPos = scrollRect.verticalNormalizedPosition;

        while (time < duration)
        {
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(startPos, position, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        scrollRect.verticalNormalizedPosition = position;

        yield return new WaitForSeconds(1);
        BlurImageRef.gameObject.SetActive(false);
        textRef.canvasRenderer.SetAlpha(0);
        textRef.CrossFadeAlpha(0.5f, 3.0f, false);
    }



}

