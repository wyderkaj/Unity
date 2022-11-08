using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenBook : MonoBehaviour
{
    #region variables

    [SerializeField] Button openBtn = null;

    [SerializeField] GameObject openedBook = null;
    [SerializeField] GameObject insideBackCover = null;

    [SerializeField] AudioSource audioSource = null;
    [SerializeField] AudioClip openBookAudioClip = null;

    private Vector3 rotationVector;

    private Quaternion startRotation;

    private bool isOpenClicked;
    private bool isCloseClicked;

    private DateTime startTime;
    private DateTime endTime;

    #endregion


    #region start 

    // Start is called before the first frame update
    private void Start()
    {
        startRotation = transform.rotation;

        if (openBtn != null)
            openBtn.onClick.AddListener(() => openBtn_Click());

        AppEvents.CloseBook += new EventHandler(closeBookBtn_Click);
    }

    #endregion

    #region upadte

    // Update is called once per frame
    void Update()
    {
        if ((isOpenClicked) || (isCloseClicked))
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;

            if (isOpenClicked)
            {
                if ((endTime - startTime).TotalSeconds >= 1)
                {
                    isOpenClicked = false;
                    gameObject.SetActive(false);
                    insideBackCover.SetActive(false);
                    openedBook.SetActive(true);

                    AppEvents.OpenBookFunction();

                    Vector3 newRotation = new Vector3(startRotation.x, 180, startRotation.y);
                    transform.rotation = Quaternion.Euler(newRotation);
                }
            }
            else if (isCloseClicked)
            {
                if ((endTime - startTime).TotalSeconds >= 1)
                {
                    isCloseClicked = false;
                  
                    Vector3 newRotation = new Vector3(startRotation.x, 0, startRotation.y);
                    transform.rotation = Quaternion.Euler(newRotation);
                }
            }

        }
    }

    #endregion

    #region open Button Click

    private void openBtn_Click()
    {
        isOpenClicked = true;
        startTime = DateTime.Now;

        rotationVector = new Vector3(0, 180, 0);

        PlaySound();
    }

    #endregion

    #region close book button click

    private void closeBookBtn_Click(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        insideBackCover.SetActive(true);
        openedBook.SetActive(false);

        isCloseClicked = true;
        startTime = DateTime.Now;

        rotationVector = new Vector3(0, -180, 0);

        PlaySound();
    }

    #endregion

    #region play sound

    private void PlaySound()
    {
        if ((audioSource != null) && (openBookAudioClip != null))
        {
            audioSource.PlayOneShot(openBookAudioClip);
        }
    }

    #endregion
}
