public class Runner
{
    private Health _runnerHealth;
    private RunnerMovement _runnerMovement;

    public Health RunnerHealth => _runnerHealth;
    public RunnerMovement RunnerMovement => _runnerMovement;

    public Runner(float middleTrackPosition, float trackGape, float cameraTrackGape)
    {
            _runnerHealth = new Health();
            _runnerMovement = new RunnerMovement(this, middleTrackPosition, trackGape, cameraTrackGape);
    }
}