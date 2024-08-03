using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CinemachineSliderJoint : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    [SerializeField] CinemachineVirtualCamera targetCamera;
    [SerializeField] PlayerMovement playerMovement;
    private Vector2 connectedPosition;
    private Vector2 currentPosition;
    private float breakDistance = 0.2f;
    [SerializeField] GameObject cutScenePanel;
    [SerializeField] TextMeshProUGUI cutSceneText;
    [SerializeField] float changeInterval = 20.0f;
    private List<string> cutScenePhrases = new List<string>
    {
        "Добро пожаловать на уровень!",
        "Герои всегда приходят вовремя.",
        "Ты готов к новым приключениям?",
        "Начнем наше путешествие!"
    };
    private int currentPhraseIndex = 0;
    private float timer;


    void Start()
    {
        timer = changeInterval;
        if (cutSceneText != null && cutScenePhrases.Count > 0)
        {
            cutSceneText.text = cutScenePhrases[currentPhraseIndex];
        }
        sliderJoint = GetComponent<SliderJoint2D>();
        playerMovement.enabled = false;
        connectedPosition = sliderJoint.connectedBody.position;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = changeInterval;
            currentPhraseIndex = (currentPhraseIndex + 1) % cutScenePhrases.Count;

            if (cutSceneText != null)
            {
                cutSceneText.text = cutScenePhrases[currentPhraseIndex];
            }
        }

        currentPosition = gameObject.GetComponent<Rigidbody2D>().position;

        if (Vector2.Distance(connectedPosition, currentPosition) <= breakDistance)
        {
            cutScenePanel.SetActive(false);
            playerMovement.enabled = true;
            Destroy(targetCamera.gameObject);
            Destroy(gameObject);

        }
    }
}
