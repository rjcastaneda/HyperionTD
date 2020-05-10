using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [Header("Tutorial Steps")]
    public bool stepOneDone;
    public bool stepTwoDone;
    public bool stepThreeDone;
    public bool stepFourDone;
    public bool stepFiveDone;
    public bool stepSixDone;
    public bool stepSevenDone;
    public bool stepEightDone;
    public bool stepNineDone;
    public bool stepTenDone;
    public bool stepElevenDone;
    public bool stepTwelveDone;
    public bool stepThirteenDone;
    public bool stepFourteenDone;
    public bool stepFifteenDone;

    [Header("Tutorial Objects")]
    public GameObject UIBlocker;
    public GameObject stepOneGO;
    public GameObject stepTwoGO;
    public GameObject stepThreeGO;
    public GameObject stepFourGO;
    public GameObject stepFiveGO;
    public GameObject stepSixGO;
    public GameObject stepSevenGO;
    public GameObject stepEightGO;
    public GameObject stepNineGO;
    public GameObject stepTenGO;
    public GameObject stepElevenGO;
    public GameObject stepTwelveGO;
    public GameObject stepThirteenGO;
    public GameObject stepFourteenGO;
    public GameObject stepFifteenGO;
    private GameObject BuildArea;
    private GameObject TutorialTurret;

    private void Update()
    {
        TutorialSteps();
    }

    public void TutorialSteps()
    {
        if(!stepOneDone){ StepOne(); return; }
        if (!stepTwoDone){ StepTwo(); return; }
        if (!stepThreeDone){ StepThree(); return; }
        if (!stepFourDone){ StepFour(); return; }
        if(!stepFiveDone){ StepFive(); return; }
        if (!stepSixDone){ StepSix(); return; }
        if (!stepSevenDone){ StepSeven(); return; }
        if (!stepEightDone) { StepEight(); return; }
        if (!stepNineDone) { StepNine(); return; }
        if (!stepTenDone) { StepTen(); return; }
        if (!stepElevenDone) { StepEleven(); return; }
        if (!stepTwelveDone) { StepTwelve(); return; }
        if (!stepThirteenDone) { StepThirteen(); return; }
        if (!stepFourteenDone) { StepFourteen(); return; }
        if (!stepFifteenDone) { StepFifteen(); return; }
    }

    private void StepOne()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            stepOneGO.SetActive(false);
            stepTwoGO.SetActive(true);
            stepOneDone = true;
        }
    }

    private void StepTwo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepTwoGO.SetActive(false);
            stepThreeGO.SetActive(true);
            stepTwoDone = true;
        }
    }

    private void StepThree()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepThreeGO.SetActive(false);
            stepFourGO.SetActive(true);
            stepThreeDone = true;
        }
    }

    private void StepFour()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepFourGO.SetActive(false);
            stepFiveGO.SetActive(true);
            stepFourDone = true;
        }
    }

    private void StepFive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepFiveGO.SetActive(false);
            stepSixGO.SetActive(true);
            stepFiveDone = true;
        }
    }

    private void StepSix()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepSixGO.SetActive(false);
            stepSevenGO.SetActive(true);
            stepSixDone = true;
        }
    }

    private void StepSeven()
    {
        UIBlocker.SetActive(false);
        BuildArea = GameObject.Find("BuildArea");
        Transform BATransform = BuildArea.transform;
        foreach (Transform child in BATransform)
        {
            BuildSquare _buildSquare = child.gameObject.GetComponent<BuildSquare>();
            if(_buildSquare.turret != null)
            {
                TutorialTurret = _buildSquare.turret;
                UIBlocker.SetActive(true);
                stepSevenGO.SetActive(false);
                stepEightGO.SetActive(true);
                stepSevenDone = true;
            }
        }
        
    }

    private void StepEight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIBlocker.SetActive(false);
            stepEightGO.SetActive(false);
            stepNineGO.SetActive(true);
            stepEightDone = true;
        }
    }

    private void StepNine()
    {
        Turret theTurret = TutorialTurret.GetComponent<Turret>();
        if(theTurret.level >= theTurret.maxLevel)
        {
            UIBlocker.SetActive(true);
            stepNineGO.SetActive(false);
            stepTenGO.SetActive(true);
            stepNineDone = true;
        }
    }

    private void StepTen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepTenGO.SetActive(false);
            stepElevenGO.SetActive(true);
            stepTenDone = true;
        }
    }

    private void StepEleven()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepElevenGO.SetActive(false);
            stepTwelveGO.SetActive(true);
            stepElevenDone = true;
        }
    }

    private void StepTwelve()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepTwelveGO.SetActive(false);
            stepThirteenGO.SetActive(true);
            stepTwelveDone = true;
        }
    }

    private void StepThirteen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepThirteenGO.SetActive(false);
            stepFourteenGO.SetActive(true);
            stepThirteenDone = true;
        }
    }

    private void StepFourteen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepFourteenGO.SetActive(false);
            stepFifteenGO.SetActive(true);
            stepFourteenDone = true;
        }
    }

    private void StepFifteen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepFifteenGO.SetActive(false);
            stepFifteenDone = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
