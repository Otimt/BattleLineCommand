using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleLineCommand.Data;

namespace BattleLineCommand.View{
    public class FighterController : MonoBehaviour
    {
        FighterData data = new FighterData();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseEnter(){
            this.gameObject.GetComponent<Outline>().enabled=true;
            Debug.Log("OnMouseEnter");
        }
        void OnMouseExit(){
            this.gameObject.GetComponent<Outline>().enabled=false;
            Debug.Log("OnMouseExit");
        }

        // 根据坐标,返回 边长为 √3的六边形 中心位置
        public float[] GetCellCenter (int indexX, int indexY) {
            double sqrt3=System.Math.Sqrt(3);
            double y = indexY*2.0 - indexX%2.0;
            double x = (1 + (indexX-1)*1.5)/sqrt3*2;
            float[] res = {(float)x, (float)y};
            return res;
        }

    }
}

