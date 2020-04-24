namespace Escalada.Models.ViewModels
{
  public class EventViewModelFactory
  {
    public static EventViewModel BuildViewModel(Event @event)
    {
      return new EventViewModel
      {
      };
    }

    public static EventViewModel BuildCreateModel()
    {
      return BuildViewModel(null);
    }
  }
}