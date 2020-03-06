namespace ProfileWebAPI.Models
{
    public interface IState
    {
        string StateAbrev { get; set; }
        string StateName { get; set; }
    }
}