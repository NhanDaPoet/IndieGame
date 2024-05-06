using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour, IDamageable
{
    public Stats stats;
    public GameObject FloatingTextPrefab;
    [SerializeField] private GameObject hitParticles;
    private Animator anim;

    public void Damage(float amount)
    {
        Debug.Log(amount + " Damage taken");

        Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        anim.SetTrigger("damage");
        /*        Destroy(gameObject);*/
        if (FloatingTextPrefab)
        {
            ShowFloatingText();
        }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void ShowFloatingText()
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = stats.currentHealth.ToString();
    }
}
