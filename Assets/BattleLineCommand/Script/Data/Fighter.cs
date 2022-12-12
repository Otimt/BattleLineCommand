namespace BattleLineCommand.Data{
	public class Fighter {
	
		private int id;
		private string name;
		
		private int level; //等级
		private int experience; //经验
		private int[] position; // 位置

		public int attack;//攻击
		public int defenses;//防御
		public int speed;//速度
		public int fieldOfVision; //视野
		public int range;//射程

		public int direction;//方向
		
		// 状态：
		// 	1.行军 速*2 攻/2 防/2
		// 	2.驻防 速*0 攻/1 防*2
		// 	3.进攻 速/2 攻*2 防*1
		// 	4.溃败 速*2 攻*0 防/2
		public int status;//状态
		
		// 携带
		public int ammunition;//弹药
		public int food;//食物
		public int oils;//油料
			
		public int morale;//士气
		public int People;//人员
		
		// 被灭
		void distroy(){
		}
		// 弹药消耗 10
		void ammunitionCost(){
		}
		// 食物消耗 10
		void foodCost(){
		}
		// 油料消耗 
		void oilsCost(){
		}
		// 人员损失
		void PeopleCost(){
		}
		// 士气增减
		void moraleCost(){
			// 食物充足 +1
			// 弹药充足 +1
			// 消灭敌军 +1
			// 人员损失超30% -1
			// 附近友军被灭 -1
			// 侧后被攻击 -1
			// 补给被切断 -2
		}
		// 获取视野单元格
		void getVisibleCell() {
		}
	}
}