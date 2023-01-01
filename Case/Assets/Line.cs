using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Line : MonoBehaviour
{
    private bool _isUsed;
    public Movement PlayerMovement;
    public GameObject obj ;
    public FinishText MyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isUsed) return;

        if (other.transform.parent.parent.CompareTag("Player"))
        {
            PlayerMovement.enabled = false;
            MyText.OnFinish(PlayerMovement.GetComponent<PlayerManager>().Score);
            obj.SetActive(true);
            _isUsed = true;
        }

        
    }
}
