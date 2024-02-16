[System.Serializable]
public struct GameDictionaryBehaviour {
    public IPlayerBehaviour craft;      // 제작하기
    public IPlayerBehaviour fire;       // 모닥불
    public IPlayerBehaviour move;       // 이동하기
    public IPlayerBehaviour outside;    // 야외
    public IPlayerBehaviour rest;       // 휴식 취하기
    public IPlayerBehaviour search;     // 탐색하기
    public IPlayerBehaviour shelter;    // 휴식처
    public IPlayerBehaviour sleep;      // 잠자기
    public IPlayerBehaviour water;      // 빗물 모으기
}