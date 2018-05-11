using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    /* parser.cs에서 string 값 읽어오기
     * 그 값으로 Area 클래스 초기화 (Area 붙은 빈 게임오브젝트 생성)
     * 초기화된 Tile값으로 Tile 게임오브젝트 생성
     * (Tile 컴포넌트, mesh 렌더러 붙은 게임오브젝트)
     * Instantiate 함수로 게임오브젝트 동적 생성(List<string>)
     * GetComponent<Area, Tile>로 각 클래스 초기화
     * 프리팹 사용 */

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
