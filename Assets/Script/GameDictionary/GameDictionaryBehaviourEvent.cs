[System.Serializable]
public struct GameDictionaryBehaviourEvent {
    public IGameRandomEvent injured;   // 부상을 입음
    public IGameRandomEvent inDanger;  // 위험에 빠짐
    public IGameRandomEvent hunting;   // 동물을 사냥함
    public IGameRandomEvent farming;   // 아이템을 노획함
}