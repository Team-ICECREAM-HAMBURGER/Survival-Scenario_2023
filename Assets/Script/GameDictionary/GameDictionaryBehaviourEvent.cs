[System.Serializable]
public struct GameDictionaryBehaviourEvent {
    public IPlayerBehaviourEvent injured;   // 부상을 입음
    public IPlayerBehaviourEvent inDanger;  // 위험에 빠짐
    public IPlayerBehaviourEvent hunting;   // 동물을 사냥함
    public IPlayerBehaviourEvent farming;   // 아이템을 노획함
}