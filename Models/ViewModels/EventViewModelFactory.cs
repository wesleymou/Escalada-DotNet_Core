namespace Escalada.Models.ViewModels
{
    public class EventViewModelFactory
    {
        public static EventEditViewModel BuildEditViewModel(Event @event)
        {
            return new EventEditViewModel
            {
                Event = @event
            };
        }

        public static EventEditViewModel BuildCreateViewModel()
        {
            return BuildEditViewModel(null);
        }
    }
}