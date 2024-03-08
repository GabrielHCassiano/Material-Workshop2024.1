using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    [SerializeField] private GameObject cherrySprite;
    [SerializeField] private GameObject cherry;
    private GameObject cherryPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cherrySprite.activeSelf == true)
        {
            cherrySprite.gameObject.SetActive(false);
            cherryPlayer = Instantiate(cherry, collision.transform.position, collision.transform.rotation, collision.transform);
            StartCoroutine(CherryCooldown());
        }

    }

    public IEnumerator CherryCooldown()
    {
        print("oi");
        yield return new WaitForSeconds(5);
        cherrySprite.gameObject.SetActive(true);
        Destroy(cherryPlayer.gameObject);
    }
}

