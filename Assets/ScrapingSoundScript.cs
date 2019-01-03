using UnityEngine;

public class ScrapingSoundScript : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string scraping;
    FMOD.Studio.EventInstance ScrapingSound;
    FMOD.Studio.ParameterInstance SoundorNot;
    float xvel;
    float zvel;
    float yvel;
    private Rigidbody rb;
    [SerializeField] bool destroyOption;



    // Use this for initialization
    void Start()
    {

        ScrapingSound = FMODUnity.RuntimeManager.CreateInstance(scraping);
        ScrapingSound.getParameter("Stoporgo", out SoundorNot);
        ScrapingSound.start();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()

    {
        xvel = Mathf.Min(6, Mathf.Abs(rb.velocity.x)); // minst 6 eller det andra värdet
        zvel = Mathf.Min(6, Mathf.Abs(rb.velocity.z));
        yvel = Mathf.Min(6, Mathf.Abs(rb.velocity.y));






        if (xvel > 0f)
        {
            SoundorNot.setValue(xvel);
        }
        if (zvel > 0f)
        {
            SoundorNot.setValue(zvel);
        }
        else if (xvel <= 0 && zvel <= 0)
        {
            SoundorNot.setValue(0);
        }


        if (yvel > 0.1f)
        {
            SoundorNot.setValue(0);
            //ScrapingSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            //this.enabled = false;
        }
        if (destroyOption == true)
        {
            if (yvel > 5.9f)
            {
                Destroy(gameObject, 3);
            }
        }
    }

}
