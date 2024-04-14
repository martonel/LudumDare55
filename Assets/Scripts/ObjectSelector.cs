using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectSelector : MonoBehaviour
{
    public List<GameObject> selectedGameObjects = new List<GameObject>(); // List to store selected game objects
    public Color defaultColor = Color.red; // Default color when not selected
    public Color selectedColor = Color.green; // Color when selected
    public Fighting fightingSystem;
    private int summonNumber = 1;
    public int level;

    public Image summonCircleImage;
    public List<Color> colorList;
    public ParticleSystem particleSystem;

    public Animator anim;
    public Animator mainAnim;

    public Button startButton;
    public InactiveObjectAnimator inactiveObjectAnimator;

    public AudioSource audioSource;

    private void Start()
    {
        level = 1;
    }

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            // Create a pointer event data object
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            // Set the position of the pointer event data to the mouse position
            eventData.position = Input.mousePosition;

            // Create a list to store the raycast results
            List<RaycastResult> results = new List<RaycastResult>();

            // Perform the raycast using the GraphicRaycaster attached to the canvas
            GraphicRaycaster raycaster = GetComponent<GraphicRaycaster>();
            raycaster.Raycast(eventData, results);

            // Check if a UI image was clicked
            foreach (RaycastResult result in results)
            {
                // Get the game object from the clicked UI image
                GameObject gameObject = result.gameObject;
                // If a game object is found, add or remove it from the selected game objects list
                if (gameObject != null && gameObject.CompareTag("chooser"))
                {
                    if (selectedGameObjects.Contains(gameObject))
                    {
                        // Deselect the game object
                        selectedGameObjects.Remove(gameObject);
                        // Restore its default color
                        SetGameObjectColor(gameObject, defaultColor);
                    }
                    else
                    {

                        if (selectedGameObjects.Count < 2)
                        {
                            // Select the game object
                            selectedGameObjects.Add(gameObject);
                            // Change its color to selected color
                            SetGameObjectColor(gameObject, selectedColor);
                        }
                        if(selectedGameObjects.Count == 2)
                        {
                            setSelectedIndex();
                        }
                    }
                    startButton.interactable = selectedGameObjects.Count >= 2;


                    break;
                }
            }
        }
    }

    // Function to set the color of a game object's image component
    private void SetGameObjectColor(GameObject gameObject, Color color)
    {
        Image image = gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.color = color;
        }
    }

    private void setSelectedIndex()
    {
        int a = 0;
        int b = 0;
        Debug.Log("elindul" + a + " " + b);
        Debug.Log(selectedGameObjects[0].name + ", " + selectedGameObjects[1].name);
        if (selectedGameObjects[0].name == "InnerBox01" || selectedGameObjects[1].name == "InnerBox01")
        {
            a = 1;
        }
        if (selectedGameObjects[0].name == "InnerBox02" || selectedGameObjects[1].name == "InnerBox02")
        {
            if(a == 0)
            {
                a = 2;
            }
            else
            {
                b = 2;
            }
        }
        if (selectedGameObjects[0].name == "InnerBox03" || selectedGameObjects[1].name == "InnerBox03")
        {
            if (a == 0)
            {
                a = 3;
            }
            else
            {
                b = 3;
            }
        }
        if (selectedGameObjects[0].name == "InnerBox04" || selectedGameObjects[1].name == "InnerBox04")
        {
            if (a == 0)
            {
                a = 4;
            }
            else
            {
                b = 4;
            }
        }
        if (selectedGameObjects[0].name == "InnerBox05" || selectedGameObjects[1].name == "InnerBox05")
        {
            b = 5;
        }
        Debug.Log("final a + b: " + a + ", " + b);
        getPoisonType(a, b);
    }

    private void getPoisonType(int a, int b)
    {
        int num = 0;
        Debug.Log(a + " " + b);
        if(a == 1)
        {
            if(b == 2) {
                num = 1;
            //elsõ páros
            }else if(b == 3)
            {
                num = 2;
                //második páros
            }else if (b == 4)
            {
                num = 3;
                //harmadik páros
            }else if (b == 5)
            {  
                num = 4;
                //negyedik páros
            }
        }else if(a == 2)
        {
            if(b==3)
            {
                num = 5;
                //ötödik páros
            }else if (b == 4)
            {
                num = 6;
                //hatodik páros
            }else if(b == 5)
            {
                num = 7;
                //hetedik páros
            }
        }else if(a == 3)
        {
            if(b == 4)
            {
                num = 8;
                //nyolcadik páros
            }else if(b==5)
            {
                num = 9;
                //kilencedik páros
            }
        }else if (a == 4)
        {
            if(b == 5)
            {
                num = 10;
                //tizedik páros
            }
        }
        summonNumber = num;
        Debug.Log("párosítás száma: " + num);
        if(summonNumber == 5)
        {
            mainAnim.SetBool("isWin", true);
        }
        else
        {
            mainAnim.SetBool("isWin", false);
        }

        Debug.Log(num);
        if (num > 0)
        {
            getAnimByLevel(num);
            summonCircleImage.color = colorList[num - 1];
            particleSystem.startColor = colorList[num - 1];

        }
        //fightingSystem.setSummonedIndex(num);

    }

    public void getAnimByLevel(int num) {
        string summonAnimName = "summon" + num;
        inactiveObjectAnimator.animationName = summonAnimName;
    }
}