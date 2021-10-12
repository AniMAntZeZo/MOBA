using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilites : MonoBehaviour
{
    [Header("AbilityQ")]
    public Image abilityCouldownImage1;
    public Text textCouldoun1;
    public float couldown1 = 5f;
    public float oldCouldown1;
    bool isColdoun1 = false;
    public KeyCode abiliti1;

    //Abiliti 1 Input Variables
    Vector3 position;
    public Canvas ability1Canvas;
    public Image skillshot;
    public Transform player;

    [Header("AbilityW")]
    public Image abilityCouldownImage2;
    public Text textCouldoun2;
    public float couldown2;
    public float oldCouldown2;
    bool isColdoun2 = false;
    public KeyCode abiliti2;

    //Ability 2 Input Variables
    public Image targetCircle;
    public Image indicatorRangeCircleW;
    public Canvas ability2Canvas;
    private Vector3 posUp;
    public float maxAbility2dDistanse;

    [Header("AbilityE")]
    public Image abilityCouldownImage3;
    public Text textCouldoun3;
    public float couldown3 = 5f;
    public float oldCouldown3;
    bool isColdoun3 = false;
    public KeyCode abiliti3;

    //Ability E Input Variables
    public Image indicatorRangeCircleE;
    public Canvas abilityECanvas;
    private Vector3 posUpE;

    [Header("AbilityR")]
    public Image abilityCouldownImage4;
    public Text textCouldoun4;
    public float couldown4 = 5f;
    public float oldCouldown4;
    bool isColdoun4 = false;
    public KeyCode abiliti4;


    void Start()
    {
        abilityCouldownImage1.fillAmount = 0;
        abilityCouldownImage2.fillAmount = 0;
        abilityCouldownImage3.fillAmount = 0;
        abilityCouldownImage4.fillAmount = 0;
        textCouldoun1.enabled = false;
        textCouldoun2.enabled = false;
        textCouldoun3.enabled = false;
        textCouldoun4.enabled = false;

        skillshot.GetComponent<Image>().enabled = false;
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircleW.GetComponent<Image>().enabled = false;
        indicatorRangeCircleE.GetComponent<Image>().enabled = false;
    }


    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Ability 1 Input
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //Ability 2 Input
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                posUp = new Vector3(hit.point.x, 10f, hit.point.z);
                position = hit.point;
            }
        }

        //Ability1 1 Canvas Input
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        ability1Canvas.transform.rotation = Quaternion.Lerp(new Quaternion(0f, transRot.y, 0f, transRot.w), ability1Canvas.transform.rotation, 0f);

        //Ability 2 Canvas Input
        var hitPosDir = (hit.point - transform.position).normalized;
        float distanse = Vector3.Distance(hit.point, transform.position);
        distanse = Mathf.Min(distanse, maxAbility2dDistanse);

        var newHitPos = transform.position + hitPosDir * distanse;
        ability2Canvas.transform.position = new Vector3(newHitPos.x, 0.2f, newHitPos.z);
    }

    void Ability1()
    {
        if (Input.GetKey(abiliti1) && isColdoun1 == false)
        {
            skillshot.GetComponent<Image>().enabled = true;

            indicatorRangeCircleW.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;
            indicatorRangeCircleE.GetComponent<Image>().enabled = false;


        }

        if (skillshot.GetComponent<Image>().enabled == true && (Input.GetMouseButtonDown(0) || Input.GetKeyUp(abiliti1)))
        {
            isColdoun1 = true;
            textCouldoun1.enabled = true;
            textCouldoun1.text = couldown1.ToString();
            abilityCouldownImage1.fillAmount = 1;
            oldCouldown1 = couldown1;
        }

        if (isColdoun1)
        {
            abilityCouldownImage1.fillAmount -= 1 / couldown1 * Time.deltaTime;
            oldCouldown1 -= Time.deltaTime;
            textCouldoun1.text = ((int)oldCouldown1).ToString();

            skillshot.GetComponent<Image>().enabled = false;


            if (abilityCouldownImage1.fillAmount <= 0)
            {
                abilityCouldownImage1.fillAmount = 0;
                textCouldoun1.enabled = false;
                isColdoun1 = false;
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(abiliti2) && isColdoun2 == false)
        {
            indicatorRangeCircleW.GetComponent<Image>().enabled = true;
            targetCircle.GetComponent<Image>().enabled = true;

            skillshot.GetComponent<Image>().enabled = false;
            indicatorRangeCircleE.GetComponent<Image>().enabled = false;

        }

        if (targetCircle.GetComponent<Image>().enabled == true && (Input.GetMouseButtonDown(0) || Input.GetKeyUp(abiliti2)))
        {
            isColdoun2 = true;
            textCouldoun2.enabled = true;
            textCouldoun2.text = couldown2.ToString();
            abilityCouldownImage2.fillAmount = 1;
            oldCouldown2 = couldown2;
        }

        if (isColdoun2)
        {
            abilityCouldownImage2.fillAmount -= 1 / couldown2 * Time.deltaTime;
            oldCouldown2 -= Time.deltaTime;
            textCouldoun2.text = ((int)oldCouldown2).ToString();

            indicatorRangeCircleW.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

            if (abilityCouldownImage2.fillAmount <= 0)
            {
                abilityCouldownImage2.fillAmount = 0;
                textCouldoun2.enabled = false;
                isColdoun2 = false;
            }
        }
    }

    void Ability3()
    {
        if (Input.GetKey(abiliti3) && isColdoun3 == false)
        {
            indicatorRangeCircleE.GetComponent<Image>().enabled = true;

            skillshot.GetComponent<Image>().enabled = false;
            indicatorRangeCircleW.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;
        }

        if (indicatorRangeCircleE.GetComponent<Image>().enabled == true && (Input.GetMouseButtonDown(0) || Input.GetKeyUp(abiliti3)))
        {
            isColdoun3 = true;
            textCouldoun3.enabled = true;
            textCouldoun3.text = couldown3.ToString();
            abilityCouldownImage3.fillAmount = 1;
            oldCouldown3 = couldown3;
        }

        if (isColdoun3)
        {
            abilityCouldownImage3.fillAmount -= 1 / couldown3 * Time.deltaTime;
            oldCouldown3 -= Time.deltaTime;
            textCouldoun3.text = ((int)oldCouldown3).ToString();

            indicatorRangeCircleE.GetComponent<Image>().enabled = false;

            if (abilityCouldownImage3.fillAmount <= 0)
            {
                abilityCouldownImage3.fillAmount = 0;
                textCouldoun3.enabled = false;
                isColdoun3 = false;
            }
        }
    }

    void Ability4()
    {
        if (Input.GetKey(abiliti4) && isColdoun4 == false)
        {
            isColdoun4 = true;
            textCouldoun4.enabled = true;
            textCouldoun4.text = couldown4.ToString();
            abilityCouldownImage4.fillAmount = 1;
            oldCouldown4 = couldown4;

            if (GetComponent<HeroCombat>().heroAttakType == HeroCombat.HeroAttackType.Ranged)
            {
                GetComponent<HeroCombat>().heroAttakType = HeroCombat.HeroAttackType.Melee;
            }
            else if (GetComponent<HeroCombat>().heroAttakType == HeroCombat.HeroAttackType.Melee)
            {
                GetComponent<HeroCombat>().heroAttakType = HeroCombat.HeroAttackType.Ranged;
            }
        }

        if (isColdoun4)
        {
            abilityCouldownImage4.fillAmount -= 1 / couldown4 * Time.deltaTime;
            oldCouldown4 -= Time.deltaTime;
            textCouldoun4.text = ((int)oldCouldown4).ToString();

            if (abilityCouldownImage4.fillAmount <= 0)
            {
                abilityCouldownImage4.fillAmount = 0;
                textCouldoun4.enabled = false;
                isColdoun4 = false;
            }
        }
    }

}
