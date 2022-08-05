using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInstance : MonoBehaviour
{
    [SerializeField] Targetcontoller targetprefab;
    List<Targetcontoller> targets = new List<Targetcontoller>();
    Vector3 pos;
    float posx;
    float posy;
    float posz;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Target()
    {
        GameManager.ScoreUp();
        if (targets != null)
        {
            foreach (var target in targets)
            {
                Destroy(target.gameObject);
            }
        }
        targets.Clear();
        Instance();
    }
    public void Instance()
    {
        for (int i = 0; i < 1; ++i)
        {
            posx = Random.Range(-10f, 10f);
            posy = Random.Range(2f, 10f);
            posz = Random.Range(-10f, 10f);
            pos = new Vector3(posx, posy, posz);
            Targetcontoller target = Instantiate(targetprefab, pos, Quaternion.identity);
            target.Init(i);
            targets.Add(target);
        }
    }
}
