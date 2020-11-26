namespace FullStackExample.Entities
{
    public enum TaskStatus 
    { 
        // we are explicit once it goes to the db
        // we cannot aford to lose change it by 
        // adding one option in the middle
        NotStarted = 0, 
        InProgress = 1, 
        Completed = 2 
    }
}
