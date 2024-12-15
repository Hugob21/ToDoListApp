using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoListApp.Model;
using ToDoListApp.View;
using ToDoListApp.ViewModel;

namespace ToDoListApp.ViewModel;

public class PaginaPrincipalViewModel : BaseViewModel
{
    public ObservableCollection<Tarea> ListaTareas { get; set; } = new ObservableCollection<Tarea>();

    public ICommand ComandoAgregarTarea { get; }
    public ICommand ComandoEditarTarea { get; }
    public ICommand ComandoEliminarTarea { get; }

    public INavigation Navigation { get; set; } // Propiedad para manejar la navegación.

    public PaginaPrincipalViewModel()
    {
        ComandoAgregarTarea = new Command(AgregarTarea);
        ComandoEditarTarea = new Command<Tarea>(EditarTarea);
        ComandoEliminarTarea = new Command<Tarea>(EliminarTarea);
    }

    private void AgregarTarea()
    {
        var nuevaTarea = new Tarea { Nombre = "Nueva tarea", EstaCompletada = false };
        ListaTareas.Add(nuevaTarea);
    }

    private async void EditarTarea(Tarea tarea)
    {
        var paginaDetalle = new DetalleTarea
        {
            BindingContext = new DetalleTareaViewModel(tarea, this.Navigation)
        };

        await Navigation.PushAsync(paginaDetalle);
    }

    private void EliminarTarea(Tarea tarea)
    {
        if (ListaTareas.Contains(tarea))
        {
            ListaTareas.Remove(tarea);
        }
    }
}

