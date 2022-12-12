using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BattleLineCommand.View{
	public class Map : MonoBehaviour
	{
		private int cellSize = 10;

		private GameObject[] _cells;
		
		public int[][] heightArr = new int[][]{
			new int[]{1,2,1,2,3,1,4,1,3,1,2,3},
			new int[]{4,2,4,3,2,4,1,3,2,1,4,2},
			new int[]{1,1,1,4,4,3,4,3,4,1,2,4},
			new int[]{3,1,4,2,1,2,1,1,4,1,3,2},
			new int[]{1,2,1,2,3,1,4,1,3,1,2,3},
			new int[]{1,4,2,2,2,2,2,1,3,2,4,2},
			new int[]{4,4,2,3,1,4,2,2,4,3,4,4},
			new int[]{2,1,2,1,3,3,3,3,3,2,3,4},
			new int[]{4,3,3,1,4,3,1,3,3,4,3,1},
			new int[]{1,2,1,2,3,1,4,1,3,1,2,3},
			new int[]{1,4,3,4,4,4,3,3,3,3,3,4},
			new int[]{4,1,3,1,3,1,4,4,2,3,2,1}
		};

		void Start() {			
			 for (int i = 0; i < heightArr.Length; i++) {
			 	int[] arr = heightArr[i];
			 	for (int j = 0; j < arr.Length; j++) {
			 		Debug.Log(i+","+j+"："+arr[j]);
			 		//该函数返回一个object，需要强转为GameObject，第一个参数为完整绝对路径，第二个参数为Prefab名
                    GameObject cell = CreateChild(i, j, arr[j]);

//					Debug.Log ("cube MeshFilter size:"+cell.GetComponentInChildren<MeshFilter>().mesh.bounds.size);
//					Debug.Log ("cube collider size:"+cell.GetComponentInChildren<Collider>().bounds.size);
			 	}
			 }
			
			// GameObject cell = PrefabUtility.SaveAsPrefabAssetAndConnect(this.gameObject, "Assets/BattleLineCommand/Prefabs/HexTile_Clay.prefab",InteractionMode.UserAction);
			// Debug.Log(cell.transform.position);
			// cell.transform.position = new Vector3(0,0,0);

		}

		void Update () {
			
		}

		GameObject CreateChild(int indexX, int indexY, int height) {

			GameObject cellPrefab = AssetDatabase.LoadAssetAtPath("Assets/BattleLineCommand/Prefabs/HexTile_Clay.prefab", typeof(GameObject)) as GameObject;
            GameObject cell = (GameObject)Instantiate(cellPrefab);
            cell.name = "cell_"+indexX+"_"+indexY;

            Vector3 size = cell.GetComponentInChildren<Renderer>().bounds.size;
            Debug.Log ("cube Renderer size:"+size);//default:1,1,1
            float z = size.z/2;

            float[] xyArr = GetCellCenter (indexX, indexY);
			cell.transform.position = new Vector3(xyArr[0]*z, height*15, xyArr[1]*z);
			return cell;
		}



		// 根据坐标,返回 边长为 √3的六边形 中心位置
		public float[] GetCellCenter (int indexX, int indexY) {
			double sqrt3=System.Math.Sqrt(3);
			double y = indexY*2.0 - indexX%2.0;
			double x = (1 + (indexX-1)*1.5)/sqrt3*2;
			float[] res = {(float)x, (float)y};
			return res;
		}
		


		bool IsCellValid(int x, int z) {
			RaycastHit hitInfo;
			Vector3 origin = new Vector3(x * cellSize + cellSize/2, 200, z * cellSize + cellSize/2);
			Physics.Raycast(transform.TransformPoint(origin), Vector3.down, out hitInfo, Mathf.Infinity, LayerMask.GetMask("Buildings"));

			return hitInfo.collider == null;
		}

		Mesh CreateMesh() {
			Mesh mesh = new Mesh();

			mesh.name = "Grid Cell";
			mesh.vertices = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };
			mesh.triangles = new int[] { 0, 1, 2, 2, 1, 3 };
			mesh.normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
			mesh.uv = new Vector2[] { new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 1), new Vector2(0, 0) };

			return mesh;
		}

		

	}
}

