using UnityEngine;
using System.Collections;




public class CamSwitchController : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    

    // whether the needed gesture has been detected or not
    private bool bRaiseLeftHand = false;
    private bool bRaiseRightHand = false;
    private bool bSwipeRight = false;
    private bool bSwipeLeft = false;
    private bool bSwipeUp = false;
    private bool bSwipeDown = false;
    private bool userDect = false;




    /// <summary>
    /// Determines whether the user has raised his left hand.
    /// </summary>
    /// <returns><c>true</c> if the user has raised his left hand; otherwise, <c>false</c>.</returns>
    public bool IsRaiseLeftHand()
    {
        if (bRaiseLeftHand)
        {
            bRaiseLeftHand = false;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the user has raised his right hand.
    /// </summary>
    /// <returns><c>true</c> if the user has raised his right hand; otherwise, <c>false</c>.</returns>
    public bool IsRaiseRightHand()
    {
        if (bRaiseRightHand)
        {
            bRaiseRightHand = false;
            return true;
        }

        return false;
    }

    public bool IsSwipeRight()
    {
        if (bSwipeRight)
        {
            bSwipeRight = false;
            return true;
        }

        return false;
    }
    public bool IsSwipeLeft()
    {
        if (bSwipeLeft)
        {
            bSwipeLeft = false;
            return true;
        }

        return false;
    }
    public bool IsSwipeUp()
    {
        if (bSwipeUp)
        {
            bSwipeUp = false;
            return true;
        }

        return false;
    }
    public bool IsSwipeDown()
    {
        if (bSwipeDown)
        {
            bSwipeDown = false;
            return true;
        }

        return false;
    }
    /// <summary>
    /// Invoked when a new user is detected. Here you can start gesture tracking by invoking KinectManager.DetectGesture()-function.
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="userIndex">User index</param>
    public void UserDetected(long userId, int userIndex)
    {
        KinectManager manager = KinectManager.Instance;
        userDect = true;
        manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);
        manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeDown);
    }

    /// <summary>
    /// Invoked when a user gets lost. All tracked gestures for this user are cleared automatically.
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="userIndex">User index</param>
    public void UserLost(long userId, int userIndex)
    {
        userDect = false;
    }

    /// <summary>
    /// Invoked when a gesture is in progress.
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="userIndex">User index</param>
    /// <param name="gesture">Gesture type</param>
    /// <param name="progress">Gesture progress [0..1]</param>
    /// <param name="joint">Joint type</param>
    /// <param name="screenPos">Normalized viewport position</param>
    public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture,
                                  float progress, KinectInterop.JointType joint, Vector3 screenPos)
    {
    }

    /// <summary>
    /// Invoked if a gesture is completed.
    /// </summary>
    /// <returns>true</returns>
    /// <c>false</c>
    /// <param name="userId">User ID</param>
    /// <param name="userIndex">User index</param>
    /// <param name="gesture">Gesture type</param>
    /// <param name="joint">Joint type</param>
    /// <param name="screenPos">Normalized viewport position</param>
    public bool GestureCompleted(long userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectInterop.JointType joint, Vector3 screenPos)
    {
        if (gesture == KinectGestures.Gestures.RaiseLeftHand)
            bRaiseLeftHand = true;
        else if (gesture == KinectGestures.Gestures.RaiseRightHand)
            bRaiseRightHand = true;
        else if (gesture == KinectGestures.Gestures.SwipeRight)
            bSwipeRight = true;
        else if (gesture == KinectGestures.Gestures.SwipeLeft)
            bSwipeLeft = true;
        else if (gesture == KinectGestures.Gestures.SwipeUp)
            bSwipeUp = true;
        else if (gesture == KinectGestures.Gestures.SwipeDown)
            bSwipeDown = true;
        return true;
    }

    /// <summary>
    /// Invoked if a gesture is cancelled.
    /// </summary>
    /// <returns>true</returns>
    /// <c>false</c>
    /// <param name="userId">User ID</param>
    /// <param name="userIndex">User index</param>
    /// <param name="gesture">Gesture type</param>
    /// <param name="joint">Joint type</param>
    public bool GestureCancelled(long userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectInterop.JointType joint)
    {
        if (gesture == KinectGestures.Gestures.RaiseLeftHand)
            bRaiseLeftHand = false;
        else if (gesture == KinectGestures.Gestures.RaiseRightHand)
            bRaiseRightHand = false;
        else if (gesture == KinectGestures.Gestures.SwipeRight)
            bSwipeRight = false;
        else if (gesture == KinectGestures.Gestures.SwipeLeft)
            bSwipeLeft = false;
        else if (gesture == KinectGestures.Gestures.SwipeUp)
            bSwipeUp = false;
        else if (gesture == KinectGestures.Gestures.SwipeDown)
            bSwipeDown = false;

        return true;
    }

    public Camera mainCam;

    public Vector3 standBy = new Vector3(-156, 50, 107); //seite1
    public Vector3 title = new Vector3(-261, 50, 107); //seite2
    public Vector3 load = new Vector3(-368, 50, 107); //seite3
    public Vector3 main = new Vector3(-475, 50, 107); //seite4
    public Vector3 geraet = new Vector3(-585, 50, 107); //seite5
    public Vector3 profil1 = new Vector3(-697, 50, 107); //seite6
    public Vector3 profil2 = new Vector3(-805, 50, 107); //seite7
    public Vector3 cam = new Vector3(-917, 50, 107); //seite8
    public Vector3 failedrec = new Vector3(-1034, 50, 107); //seite9 not used yewt

    private int currentPage;

    void Start()
    {
        
        mainCam.transform.position = standBy;
        currentPage = 0;

    }

    
    void Update()
    {
        
        if ((userDect == true || IsRaiseRightHand() == true || Input.GetKeyDown(KeyCode.RightArrow) ) && currentPage == 0)
        {
            mainCam.transform.position = title;
            currentPage = 1;
            return;
        }
        else if ((IsSwipeRight() == true || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow)) && currentPage == 1)
        {
            mainCam.transform.position = load;
            currentPage = 2;
            return;
        }
        else if ((IsSwipeRight() == true || Input.GetKeyDown(KeyCode.RightArrow)) && currentPage == 2)
        {
            mainCam.transform.position = main;
            currentPage = 3;
            return;
        }
        else if (( IsSwipeLeft() == true || Input.GetKeyDown(KeyCode.LeftArrow)) && currentPage == 3)
        {
            mainCam.transform.position = geraet;
            currentPage = 4;
            return;
        }
        else if ((IsRaiseRightHand() == true || Input.GetKeyDown(KeyCode.Space)) && currentPage == 4)
        {
            mainCam.transform.position = main;
            currentPage = 3;
            return;
        }
        else if ((IsSwipeDown() == true || Input.GetKeyDown(KeyCode.DownArrow)) && currentPage == 3)
        {
            mainCam.transform.position = profil1;
            currentPage = 5;
            return;
        }
        else if ((IsSwipeRight() == true || Input.GetKeyDown(KeyCode.RightArrow)) && currentPage == 5)
        {
            mainCam.transform.position = profil2;
            currentPage = 6;
            return;
        }
        else if ((IsSwipeLeft() == true || Input.GetKeyDown(KeyCode.LeftArrow)) && currentPage == 6)
        {
            mainCam.transform.position = profil1;
            currentPage = 5;
            return;
        }
        else if ((IsRaiseRightHand() == true || Input.GetKeyDown(KeyCode.Space)) && currentPage == 5)
        {
            mainCam.transform.position = main;
            currentPage = 3;
            return;
        }
        else if ((IsRaiseRightHand() == true || Input.GetKeyDown(KeyCode.Space)) && currentPage == 6)
        {
            mainCam.transform.position = main;
            currentPage = 3;
            return;
        }
        else if ((IsRaiseRightHand() == true || Input.GetKeyDown(KeyCode.Space)) && currentPage == 3)
        {
            mainCam.transform.position = cam;
            currentPage = 7;
            return;
        }
        else if ((IsRaiseRightHand() == true || Input.GetKeyDown(KeyCode.Space)) && currentPage == 7)
        {
            mainCam.transform.position = main;
            currentPage = 3;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && currentPage == 1)
        {
            mainCam.transform.position = standBy;
            currentPage = 0;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && currentPage == 2)
        {
            mainCam.transform.position = standBy;
            currentPage = 0;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && currentPage == 3)
        {
            mainCam.transform.position = standBy;
            currentPage = 0;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && currentPage == 4)
        {
            mainCam.transform.position = standBy;
            currentPage = 0;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && currentPage == 5)
        {
            mainCam.transform.position = standBy;
            currentPage = 0;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && currentPage == 6)
        {
            mainCam.transform.position = standBy;
            currentPage = 0;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && currentPage == 7)
        {
            mainCam.transform.position = standBy;
            currentPage = 0;
            return;
        }
        //else if (userDect == false)
        //{
        //    mainCam.transform.position = standBy;
        //    currentPage = 0;
        //    return;
        //}
    }

    
}