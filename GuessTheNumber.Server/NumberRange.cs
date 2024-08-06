namespace GuessTheNumber.Server
{
    public readonly struct NumberRange(int min, int max)
    {
        public readonly int Min { get; } = min;
        public readonly int Max { get; } = max;
    }
}
