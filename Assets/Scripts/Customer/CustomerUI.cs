using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerUI : MonoBehaviour
{
    public enum Mood
    {
        None,
        Angry,
        Wait,
        Happy
    }

    public Mood currentMood;

    [SerializeField] private Image image;

    [SerializeField] private Sprite angrySprite;
    [SerializeField] private Sprite waitSprite;
    [SerializeField] private Sprite happySprite;

    private float activateTimer;
    private float angryTime = 1f;
    private float waitTime = 5f;
    private float happyTime = 1f;

    private bool isActive;
    void Start()
    {
        SetActivate(Mood.None, false);
    }

    private void Update()
    {
        switch(currentMood)
        {
            case Mood.None:
                Debug.Log("None");
                break;
            case Mood.Wait:
                SetImage(waitSprite, waitTime);

                ActivateMoodTimer();
                break;
            case Mood.Angry:
                SetImage(angrySprite, angryTime);

                ActivateMoodTimer();
                break;
            case Mood.Happy:
                SetImage(happySprite, happyTime);

                ActivateMoodTimer();
                break;
        }
    }

    private void ActivateMoodTimer()
    {
        if (isActive)
        {
            image.transform.rotation = Quaternion.Euler(45f, 0f, 0f);
            activateTimer -= Time.deltaTime;

            if (activateTimer <= 0)
                SetActivate(Mood.None, false);
        }
    }

    public void SetImage(Sprite sprite, float activeTime)
    {
        image.sprite = sprite;
        activateTimer = activeTime;
    }

    public void SetActivate(Mood mood, bool isActive)
    {
        currentMood = mood;
        image.gameObject.SetActive(isActive);
        this.isActive = isActive;
    }
}
