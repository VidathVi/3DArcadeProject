using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro.EditorUtilities;
public class Dialogue : MonoBehaviour
{
    public Transform Camera;
    public Animator cameraAnimator;
    public GameObject modelViewerUI;
    public GameObject textboxUI;
    public GameObject[] legoModels;
    private int legoIndex = 0;
    private Vector3 toCam = new Vector3(0f, 0.75f, 1.75f);

    public TextMeshProUGUI initialText;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI optionAText;
    public TextMeshProUGUI optionBText;
    public GameObject topicSelecter;
    public GameObject topicInteractions;
    public GameObject topicLocation;
    public GameObject dialogueSelection;
    public RawImage confirmIcon;

    public Animator animator;
    public GameObject modelView;
    public GameObject modelVieiwExit;

    public string[] dialogue;
    public int[] expression;
    public float textSpeed;

    private bool selectA = false;
    private bool selectB = false;
    private bool confirmFlag;
    private bool clawFlag1 = false;
    private bool clawFlag2 = false;
    private bool shootFlag1 = false;
    private bool shootFlag2 = false;
    private bool hockeyFlag1 = false;
    private bool hockeyFlag2 = false;
    private bool flappyFlag1 = false;
    private bool flappyFlag2 = false;
    private bool placeFlag1 = false;
    private bool placeFlag2 = false;
    private bool dialogueFinish = false;
    private int index;
    private Vector3[] ogPosition =
    {
        new Vector3(0.04f, 0.95f, 0.82f),
        new Vector3(-0.69f, 0.95f, 0.82f),
        new Vector3(0.714f, 0.95f, 0.82f),
    };
    private bool isViewer = false;

    private int hiScore = 0;
    private String[] hiScore1 = { "..?", "You mean you aren't satisfied by just watching the number go up..?" };
    private String[] hiScore2 = { "...", "There are no rewards for a High Score." };
    private String[] hiScore3 = { "Let me clarify.", "None of the minigames give you a reward for a High Score." };
    private String[] hiScore4 = { "...", "No." };

    void Start()
    {
        animator.Play("transition_stand");
        topicSelecter.SetActive(false);
        topicInteractions.SetActive(false);
        topicLocation.SetActive(false);
        dialogueSelection.SetActive(false);
        textComponent.text = string.Empty;
        Main();
    }

    void Update()
    {
        if (confirmFlag)
        {
            confirmIcon.enabled = true;
        }
        else
        {
            confirmIcon.enabled = false;
        }

        if (isViewer)
        {
            if (Input.GetMouseButton(0)){
                legoModels[legoIndex].transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 200.0f);
            }
        }


        if (clawFlag2)
        {
            index = 0;
            initialText.text = "If you're having trouble with it, you can use the mouse to help adjust your line of sight.";
            optionAText.text = "What's inside the capsules?";
            optionBText.text = "What rewards do I get for a high score?";
            dialogue = null;
            dialogueSelection.SetActive(true);
            if (selectA)
            {
                dialogue = new string[] {
                    "...",
                    "...About that.",
                    "I'm not too sure either.",
                };
                expression = new int[] { 4, 4, 1 };
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                clawFlag1 = false;
                dialogueSelection.SetActive(false);
                clawFlag2 = false;
            }
            else if (selectB)
            {
                hiScore++;
                switch (hiScore)
                {
                    case 1:
                        dialogue = hiScore1;
                        expression = new int[] { 3, 3 };
                        break;
                    case 2:
                        dialogue = hiScore2;
                        expression = new int[] { 6, 6 };
                        break;
                    case 3:
                        dialogue = hiScore3;
                        expression = new int[] { 2, 7 };
                        break;
                    case 4:
                        dialogue = hiScore4;
                        expression = new int[] { 1, 1 };
                        break;
                }
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                clawFlag1 = false;
                dialogueSelection.SetActive(false);
                clawFlag2 = false;
            }
        }

        if (shootFlag2)
        {
            index = 0;
            initialText.text = "Don't worry, you can always press R to reset your state.";
            optionAText.text = "Why is my ammunition limited?";
            optionBText.text = "What rewards do I get for a high score?";
            dialogue = null;
            dialogueSelection.SetActive(true);
            if (selectA)
            {
                dialogue = new string[] {
                    "For added challenge.",
                    "This is an arcade after all."
                };
                expression = new int[] { 1, 5, 1 };
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                shootFlag1 = false;
                dialogueSelection.SetActive(false);
                shootFlag2 = false;
            }
            else if (selectB)
            {
                hiScore++;
                switch (hiScore)
                {
                    case 1:
                        dialogue = hiScore1;
                        expression = new int[] { 3, 3 };
                        break;
                    case 2:
                        dialogue = hiScore2;
                        expression = new int[] { 6, 6 };
                        break;
                    case 3:
                        dialogue = hiScore3;
                        expression = new int[] { 2, 7 };
                        break;
                    case 4:
                        dialogue = hiScore4;
                        expression = new int[] { 1, 1 };
                        break;
                }
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                shootFlag1 = false;
                dialogueSelection.SetActive(false);
                shootFlag2 = false;
            }
        }

        if (hockeyFlag2)
        {
            index = 0;
            initialText.text = "You can use the pusher to push the puck around.";
            optionAText.text = "How does the opponent react?";
            optionBText.text = "What rewards do I get for a high score?";
            dialogue = null;
            dialogueSelection.SetActive(true);
            if (selectA)
            {
                dialogue = new string[] {
                    "It'll be on a set path that fluctuates between speeds.",
                    "You've got to time your shots right for this one."
                };
                expression = new int[] { 1, 1, 1 };
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                hockeyFlag1 = false;
                dialogueSelection.SetActive(false);
                hockeyFlag2 = false;
            }
            else if (selectB)
            {
                hiScore++;
                switch (hiScore)
                {
                    case 1:
                        dialogue = hiScore1;
                        expression = new int[] { 3, 3 };
                        break;
                    case 2:
                        dialogue = hiScore2;
                        expression = new int[] { 6, 6 };
                        break;
                    case 3:
                        dialogue = hiScore3;
                        expression = new int[] { 2, 7 };
                        break;
                    case 4:
                        dialogue = hiScore4;
                        expression = new int[] { 1, 1 };
                        break;
                }
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                hockeyFlag1 = false;
                dialogueSelection.SetActive(false);
                hockeyFlag2 = false;
            }
        }

        if (flappyFlag2)
        {
            index = 0;
            initialText.text = "Good luck.";
            optionAText.text = "Good luck?";
            optionBText.text = "What rewards do I get for a high score?";
            dialogue = null;
            dialogueSelection.SetActive(true);
            if (selectA)
            {
                dialogue = new string[] {
                    "Yeah. I find it quite hard to get a score over 20.",
                    "Give yourself a pat on the back if you manage to beat my score."
                };
                expression = new int[] { 6, 7, 1 };
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                flappyFlag1 = false;
                dialogueSelection.SetActive(false);
                flappyFlag2 = false;
            }
            else if (selectB)
            {
                hiScore++;
                switch (hiScore)
                {
                    case 1:
                        dialogue = hiScore1;
                        expression = new int[] { 3, 3 };
                        break;
                    case 2:
                        dialogue = hiScore2;
                        expression = new int[] { 6, 6 };
                        break;
                    case 3:
                        dialogue = hiScore3;
                        expression = new int[] { 2, 7 };
                        break;
                    case 4:
                        dialogue = hiScore4;
                        expression = new int[] { 1, 1 };
                        break;
                }
                initialText.enabled = false;
                textComponent.enabled = true;
                dialogueFinish = true;
                StartCoroutine(TypeLine(dialogue));
                selectA = false;
                selectB = false;
                flappyFlag1 = false;
                dialogueSelection.SetActive(false);
                flappyFlag2 = false;
            }
        }

        if (placeFlag2)
        {
            topicSelecter.SetActive(false);
            index = 0;
            initialText.text = "...";
            animator.SetInteger("Expression", 1);
            animator.SetBool("Damage", false);
            dialogue = new string[] {
                "...",
                "Yeah, I'm not originally from this world. If you can even call it that.",
                "It's kinda just...",
                "This room.",
                "There's nothing else to this place. The doors don't even open.",
                "I spawned in the same way you did.",
                "Except...",
                "You know.",
                "Nobody else was here.",
                "And so I decided to set up shop here cuz I figured it'd be fun if someone else eventually came along.",
                "...and here we are."
            };
            expression = new int[] { 1, 1, 1, 7, 7, 1, 1, 1, 7, 1, 1 };
            initialText.enabled = false;
            textComponent.enabled = true;
            dialogueFinish = true;
            StartCoroutine(TypeLine(dialogue));
            placeFlag1 = false;
            placeFlag2 = false;
        }

        if (Input.GetMouseButtonDown(0) && textComponent.enabled == true)
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

    void Main()
    {
        animator.SetBool("Damage", false);
        dialogueFinish = false;
        modelView.SetActive(true);
        topicSelecter.SetActive(true);
        initialText.text = "How can I help you?";
        textComponent.text = string.Empty;
        textComponent.enabled = false;
        animator.SetInteger("Expression", 1);
    }


    public void DialogueMovement()
    {
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"I'm pretty sure you were already told how to do that earlier though?", 
                "Well, here's a reminder.",
                "Press the WASD Buttons to move, and use your Mouse to look around.",
                "To interact with any of the games, walk up to them and press E.",
                "...",
                "Yeah, I don't know what I could possibly add to that."
        };
        expression = new int[] {3, 1, 1, 1, 1, 6};
        dialogueFinish = true;
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueClaw()
    {
        clawFlag1 = true;
        dialogueSelection.SetActive(false);
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"The claw machines, they're to your left.",
                "Press and hold the spacebar to move the claw. Let go of the spacebar to stop.",
                "The longer you hold the spacebar, the further it goes.",
                "If you're having trouble with it, you can use the mouse to help adjust your line of sight.",
                };
        expression = new int[] { 1, 1, 1, 1, 1};
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueShoot()
    {
        shootFlag1 = true;
        dialogueSelection.SetActive(false);
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"You can find the Target Practice Machine right behind you.",
                "Use the Mouse to look around, and press the Left Mouse Button to fire a shot.",
                "Don't go all trigger happy though, you've got a limited supply of bullets.",
                "Don't worry, you can always press R to reset your state.",
                };
        expression = new int[] { 1, 1, 5, 1};
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueHockey()
    {
        hockeyFlag1 = true;
        dialogueSelection.SetActive(false);
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"You should find the Air Hockey Table right next to the Target Practice Machine.",
                "This one's simple. Move your Mouse to control the pusher.",
                "You can use the pusher to push the puck around."
                };
        expression = new int[] { 1, 1, 1, 1, 1 };
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueFlappy()
    {
        flappyFlag1 = true;
        dialogueSelection.SetActive(false);
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"The Flappy Bird Machine should be over to your right.",
                "The bird's always in free fall so tap the Spacebar to make it fly.",
                "Good luck."
                };
        expression = new int[] { 4, 1, 1, 1, 1 };
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueModel()
    {
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"You can access this by clicking the button on the left of the screen.",
                "Well, the button only shows up after this conversation's done.",
                "Anyway, you'll be able to view a handful of minifigure models.",
                "Use the Mouse to control your view.",
        };
        expression = new int[] { 1, 1, 1, 1, 1, 6 };
        dialogueFinish = true;
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueJax()
    {
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"Yep.",
                "That's me."
        };
        expression = new int[] { 1, 1, 1, 1, 1, 6 };
        dialogueFinish = true;
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueOutOfPlace()
    {
        placeFlag1 = true;
        animator.SetInteger("Expression", 1);
        animator.SetBool("Damage", true);
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"...",
            "...Do I really stand out that much?",
            "......",
        };
        expression = new int[] { 6, 7, 6};
        StartCoroutine(TypeLine(dialogue));
    }
    public void DialogueEmpty()
    {
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"Well, you're the first person I've ever seen in here -- and I've been here for quite a while.",
                "Who knows? Maybe some day this place will get livelier.",
                "That said, I wouldn't get my hopes too high about another person coming along for a very long time.",
                "Soak in the atmosphere until then.",
        };
        expression = new int[] { 1, 1, 6, 7};
        dialogueFinish = true;
        StartCoroutine(TypeLine(dialogue));
    }

    public void DialogueLeave()
    {
        initialText.enabled = false;
        textComponent.enabled = true;
        index = 0;
        dialogue = new string[] {"You can exit this place any time you want, through the menu.",
                "However.",
                "The next time you wake up, you'll still be stuck here.",
                "So yeah, you're trapped in here for the rest of time.",
                "...",
                "...What do you mean it sounds like I just made that up?"
        };
        expression = new int[] { 1, 4, 4, 1, 1, 3 };
        dialogueFinish = true;
        StartCoroutine(TypeLine(dialogue));
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
        if (index < dialogue.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(dialogue));
        }
        else
        {
            animator.SetInteger("Expression", 1);
            animator.Update(0); //forces the animator to instantly start an animation
            dialogue = null;
            textComponent.enabled = false;
            initialText.enabled = true;
            if (clawFlag1)
            {
                clawFlag2 = true;
            }
            if (shootFlag1)
            {
                shootFlag2 = true;
            }
            if (hockeyFlag1)
            {
                hockeyFlag2 = true;
            }
            if (flappyFlag1)
            {
                flappyFlag2 = true;
            }
            if (placeFlag1)
            {
                placeFlag2 = true;
            }
            if (dialogueFinish) {
                Main();
            }
        }
    }

    public void ToMax()
    {
        animator.Play("transition_stand");
        cameraAnimator.Play("Camera MoveM");
        Main();
    }

    public void ToViewer()
    {
        animator.Play("relax_transition");
        cameraAnimator.Play("Camera MoveV");
        DisableMaxUI();
    }

    public void OptionAClick() {
        textComponent.text = string.Empty;
        selectA = true;
    }
    public void OptionBClick()
    {
        textComponent.text = string.Empty;
        selectB = true;
    }

    public void Interactions()
    {
        topicSelecter.SetActive(false);
        topicInteractions.SetActive(true);
    }

    public void Location()
    {
        topicSelecter.SetActive(false);
        topicLocation.SetActive(true);
    }

    public void DisableMaxUI()
    {
        topicLocation.SetActive(false);
        topicInteractions.SetActive(false);
        modelView.SetActive(false);
    }

    public void EnableViewerUI()
    {
        isViewer = true;
        legoModels[legoIndex].transform.position = toCam;
        textboxUI.SetActive(false);
        topicLocation.SetActive(false);
        topicInteractions.SetActive(false);
        topicSelecter.SetActive(false);
        modelView.SetActive(false);
        modelViewerUI.SetActive(true);
        modelVieiwExit.SetActive(true);
    }

    public void DisableViewerUI()
    {
        isViewer = false;
        textboxUI.SetActive(true);
        topicSelecter.SetActive(true);
        modelView.SetActive(true);
        modelViewerUI.SetActive(false);
        modelVieiwExit.SetActive(false);
    }

    public void LeftPress()
    {
        legoModels[legoIndex].transform.eulerAngles = new Vector3(0f, 0f, 0f);
        legoModels[legoIndex].transform.position = ogPosition[legoIndex];
        if (legoIndex > 0)
        {
            legoIndex--;
        }
        else
        {
            legoIndex = 2;
        }
        legoModels[legoIndex].transform.position = toCam;
        legoModels[legoIndex].transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void RightPress()
    {
        legoModels[legoIndex].transform.eulerAngles = new Vector3(0f, 0f, 0f);
        legoModels[legoIndex].transform.position = ogPosition[legoIndex];
        if (legoIndex < 2)
        {
            legoIndex++;
        }
        else
        {
            legoIndex = 0;
        }
        legoModels[legoIndex].transform.position = toCam;
        legoModels[legoIndex].transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void LegoAnimation()
    {
        legoModels[legoIndex].GetComponentInChildren<Animator>().Play("animation");
    }
}
