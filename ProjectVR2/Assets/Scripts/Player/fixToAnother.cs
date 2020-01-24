using UnityEngine;

public class fixToAnother : MonoBehaviour
{
    Transform playerHead, playerRightHand, playerLeftHand;
    public Transform anotherHead, anotherRight, anotherLeft;
    private void Start() {
        playerHead = GameObject.Find("CenterEyeAnchor").transform;
        playerRightHand = GameObject.Find("RightHandAnchor").transform;
        playerLeftHand = GameObject.Find("LeftHandAnchor").transform;
    }
    private void LateUpdate() {
        anotherHead.localPosition = playerHead.localPosition;
        anotherLeft.localPosition = playerLeftHand.localPosition;
        anotherRight.localPosition = playerRightHand.localPosition;
        anotherHead.localEulerAngles = playerHead.localEulerAngles;
        anotherLeft.localEulerAngles = playerLeftHand.localEulerAngles;
        anotherRight.localEulerAngles = playerRightHand.localEulerAngles;
    }
}
