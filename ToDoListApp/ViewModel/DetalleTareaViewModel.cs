using System.Windows.Input;
using ToDoListApp.Model;

namespace ToDoListApp.ViewModel;

public class DetalleTareaViewModel : BaseViewModel
{
    public Tarea Tarea { get; set; }

    public ICommand ComandoGuardar { get; }

    private readonly INavigation _navigation;

    public DetalleTareaViewModel(Tarea tarea, INavigation navigation)
    {
        Tarea = tarea;
        _navigation = navigation;
        ComandoGuardar = new Command(GuardarTarea);
    }

    private async void GuardarTarea()
    {
        await _navigation.PopAsync(); // Vuelve a la página principal.
    }
}

