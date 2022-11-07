using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PunchAnim : MonoBehaviour
{
    public float punchScale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        iTween.PunchScale(gameObject,
            iTween.Hash(
                "looptype", iTween.LoopType.loop,
                "amount", new Vector3(transform.localScale.x * punchScale, transform.localScale.y * punchScale, transform.localScale.z * punchScale)
                ));
        
        // GenerateAutomaticTreePainting();
    }

    /// <summary>
    /// Once generated, store in prefabs
    /// </summary>
    private static void GenerateAutomaticTreePainting()
    {
        // test auto painting
        var gos = GameObject.FindGameObjectsWithTag("tree");

        var brown = Resources.Load("Brown") as Material;
        var green = Resources.Load("Green") as Material;
        var darkGreen = Resources.Load("DarkGreen") as Material;

        foreach (var go in gos)
        {
            print("go name : " + go?.name);

            foreach (Transform childTransform in go.transform)
            {
                var w = childTransform.GetComponent<Component>();
                print("CHILD : " + w);

                if (w.name == "Trunk")
                {
                    var me = w.gameObject.GetComponent<MeshRenderer>();
                    var newMat = new Material[1];
                    newMat[0] = brown;
                    me.materials = newMat;
                    print(me);
                }
                else if (w.name == "Leaves")
                {
                    var me = w.gameObject.GetComponent<MeshRenderer>();
                    var newMat = new Material[1];
                    var rand = Random.Range(0, 2);
                    newMat[0] = rand < 1 ? green : darkGreen;
                    me.materials = newMat;
                }
            }
        }
    }
}
