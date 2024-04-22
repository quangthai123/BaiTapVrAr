using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private void SetActiveRightAnswerUI()
    {
        GameManager.Instance.SetActiveRightAnswerUI();
    }
    private void SetActiveWrongAnswerUI()
    {
        GameManager.Instance.SetActiveWrongAnswerUI();
    }
}
