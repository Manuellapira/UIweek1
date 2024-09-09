using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIAnimationManager : MonoBehaviour
{

    public GameObject button;
    public Vector3 shrinkSize,enlargeSize;
    public float animationDuration;
    public Vector3 finalPosition;
    public Ease easing;
    public Vector3 initalPosition;
    public Vector3 rotation;
    public void ShrinkUI ()
    {
        button.transform.DOScale(shrinkSize, animationDuration).OnComplete(() => button.transform.DOScale(Vector3.one, animationDuration));
    }
    public void EnlargeUI()
    {
        button.transform.DOScale(enlargeSize, animationDuration).OnComplete(() => button.transform.DOScale(Vector3.one, animationDuration));
    }

    public void MoveButton()
    {
        //move = vector3 end value, anition duration 
        button.transform.DOLocalMove(finalPosition, animationDuration).SetEase(easing).OnComplete(()=> ReversePositionButton());
    }

    public void ReversePositionButton()
    {
        button.transform.DOLocalMove(initalPosition, animationDuration).SetEase(easing).OnComplete(()=> MoveButton());
    }

    public void SkakeButton()
    {
        //float duration, strength = 1 min, vvibration = 10 min, randomness 90 min
        button.transform.DOShakePosition(5,105,10,90);
        button.transform.DOShakeScale(5, 105, 10, 90);
    }

    public void FadeButton()
    {
        Image colorButton;
        colorButton = button.GetComponent<Image>();
        colorButton.DOFade(0, animationDuration);
    }
    public void RotateButton()
    {
        //vector3 , duration rotatemode
        button.transform.DOLocalRotate(rotation,5, RotateMode.FastBeyond360).SetEase(easing);
    }

    public void JumpButton()
    {
        //vector3 end position, float jump power, int number of jumps, float duration
        button.transform.DOLocalJump(finalPosition ,3.5f, 6, 3);
    }
}
