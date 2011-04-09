namespace AggregateSample
{
	public interface IUnderlying : ITrade
	{
		ITrade ExerciseAt(decimal strike);
		IUnderlying Clone();
	}
}