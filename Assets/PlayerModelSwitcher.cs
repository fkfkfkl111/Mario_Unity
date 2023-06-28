using UnityEngine;

public class PlayerModelSwitcher : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    public float switchInterval = 3.0f;

    private bool isModel1Active = true;

    private void Start()
    {
        InvokeRepeating("SwitchPlayerModel", switchInterval, switchInterval);
    }

    private void SwitchPlayerModel()
    {
        if (isModel1Active)
        {
            model1.transform.SetParent(transform);
            model2.transform.SetParent(null);
            isModel1Active = false;
        }
        else
        {
            model2.transform.SetParent(transform);
            model1.transform.SetParent(null);
            isModel1Active = true;
        }
    }
}
