namespace StudentSystem.Exception
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string resource, int id) : base($"{resource} with ID {id} not found.", "NotFound")
        {

        }
    }
}
