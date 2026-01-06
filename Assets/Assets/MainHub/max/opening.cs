using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro.EditorUtilities;

public class opening : MonoBehaviour
{
    public GameObject interactButton;
    public GameObject skipButton;
    public GameObject dialogueBox;
    public TextMeshProUGUI initialText;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI moveText;
    public GameObject player;

    public Animator animator;
    public Animator lights;
    public string[] dialogue;
    public int[] expression;
    public float textSpeed;
    private bool confirmFlag;
    private int index;
    private bool maxFlag = false;

    void Start()
    {
        dialogue = new string[] {
                    "Oh hey, a new face.",
                    "Welcome to the arcade.",
                    "The name's Max. I work here.",
                    "...Hold on.",
                    "...",
                    "There we go.",
                    "While you're here, why don't you give some of the games a try?",
                    "Feel free to ask me any questions if you've got any.",
                    "Off you go."
                };
        expression = new int[] { 1, 11, 1, 1, 1, 1, 1, 1, 5 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactButton.activeSelf == true)
        {
            maxFlag = true;
        }
        if (maxFlag)
        {
            GetComponent<Collider>().enabled = false;
            interactButton.SetActive(false);
            moveText.text = "";
            dialogueBox.SetActive(true);
            player.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && textComponent.enabled == true && maxFlag)
        {
            if (textComponent.text == dialogue[index])
            {
                confirmFlag = false;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogue[index];
                confirmFlag = true;
            }
        }
    }

    IEnumerator TypeLine(String[] dialogue)
    {
        animator.SetInteger("Expression", expression[index]);
        animator.Update(0); //forces the animator to instantly start an animation
        confirmFlag = false;
        foreach (char c in dialogue[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        confirmFlag = true;
    }

    void NextLine()
    {
        if (index == 3)
        {
            animator.Play("clap");
            lights.Play("turn on");
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(dialogue));
        }
        else if (index < dialogue.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(dialogue));
        }
        else
        {
            //Switch scenes here
            animator.SetInteger("Expression", 1);
            animator.Update(0); //forces the animator to instantly start an animation
            dialogue = null;
            textComponent.enabled = false;
            initialText.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(false);
        }
    }
}
