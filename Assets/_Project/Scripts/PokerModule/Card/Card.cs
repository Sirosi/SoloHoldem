[System.Serializable]
public struct Card
{
    public SuitType Type;
    public byte Value;

    public Card(SuitType type, byte value)
    {
        Type = type;
        Value = value;
    }

    public override readonly string ToString()
    {
        return $"[{Type}, {Value}]";
    }
}