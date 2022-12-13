using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//巡游模式摄像机控制
namespace BattleLineCommand.View{
	public class CameraMove : MonoBehaviour {
	 
		public static CameraMove Instance = null;
	 
		private Vector3 rotaVector3;
		
		//旋转参数
		private float yspeed = 0.9f;
		private float moveStep = 10;
		
		
		
		void Awake ()
		{
			Instance = this;
		}
		
		void Start()
		{
			rotaVector3 = transform.localEulerAngles;
			
		}
		// Update is called once per frame
		void Update()
		{
			
		}
		
		// Update is called once per frame
		void FixedUpdate () {
			float moveFB = 0;
			float moveLR = 0;
			float moveX = 0;
			float moveY = 0;
			float moveZ = 0;
			
			
			// todo 旋转
			if (Input.GetKey(KeyCode.Q)) {
				rotaVector3.y += yspeed;
				transform.rotation = Quaternion.Euler(rotaVector3);
				//transform.Rotate(0,rotaVector3.y / 180 * Mathf.PI ,0,Space.World);
			}else if (Input.GetKey(KeyCode.E)) {
				rotaVector3.y -= yspeed;
				transform.rotation = Quaternion.Euler(rotaVector3);
				//transform.Rotate(0,rotaVector3.y / 180 * Mathf.PI,0,Space.World);
			}

			
			if (Input.GetKey(KeyCode.W)) {
				moveFB = 1 * moveStep;
			} else if (Input.GetKey(KeyCode.S)) {
				moveFB = -1 * moveStep;
			}
			if (Input.GetKey(KeyCode.A)) {
				moveLR = -1 * moveStep;
			} else if (Input.GetKey(KeyCode.D)) {
				moveLR = 1 * moveStep;
			}
			// 斜向移动，总速度不变
			if(moveLR != 0 && moveFB != 0){
				moveLR = moveLR * Mathf.Sin(Mathf.PI/4);
				moveFB = moveFB * Mathf.Sin(Mathf.PI/4);
			}
			if (moveLR != 0 || moveFB != 0) {
				moveX = -(moveFB * Mathf.Sin(-rotaVector3.y / 180 * Mathf.PI) + moveLR * Mathf.Sin((-rotaVector3.y / 180 - 0.5f) * Mathf.PI));
				moveZ = moveFB * Mathf.Cos(-rotaVector3.y / 180 * Mathf.PI) + moveLR * Mathf.Cos((-rotaVector3.y / 180 - 0.5f) * Mathf.PI);
				transform.Translate(moveX,moveY,moveZ,Space.World);
			}
			
			//transform.Translate(dirVector3 * paramater,Space.Self);
		   
		}
		
		
	}
}
	
