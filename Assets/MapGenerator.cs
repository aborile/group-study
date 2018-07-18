using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviour {
    /* 그 값으로 Area 클래스 초기화 (Area 붙은 빈 게임오브젝트 생성)
     * 초기화된 Tile값으로 Tile 게임오브젝트 생성
     * (Tile 컴포넌트, mesh 렌더러 붙은 게임오브젝트)
     * Instantiate 함수로 게임오브젝트 동적 생성(List<string>)
     * GetComponent<Area, Tile>로 각 클래스 초기화
     * 프리팹 사용 */
     
    public List<List<string[]>> tileArr;
    public parser p;
    public Area area;
    Vector3 areaP;

	// Use this for initialization
	void Start () {
        int stageNum = SceneManager.GetActiveScene().name.ToCharArray()[SceneManager.GetActiveScene().name.Length - 1] - '1';
        Debug.Log(stageNum);

        tileArr = new List<List<string[]>>();     //parser에서 읽어온 값 저장
        p = GameObject.Find("GameObject").GetComponent<parser>();         //parser 스크립트 불러옴
        tileArr = p.makeData("map.txt");     //파일에서 읽은 값 담음

        
        for (int i = 0; i < tileArr[stageNum].Count; i++)
        {
            areaP = new Vector3(i * 2 * 9, 0, i * 2 * area.len);
            //areaP = new Vector3(0, 0, i * 2 * area.len);
            Area makeArea = Instantiate(area, areaP, transform.rotation);
            makeArea.gameObject.name = "Tile " + i;
            makeArea.setTileType(tileArr[stageNum][i]);
            makeArea.GetComponent<Area>(); //해당 area의 tile type 전달
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
