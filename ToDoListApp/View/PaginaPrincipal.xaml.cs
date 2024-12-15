using ToDoListApp.ViewModel;

namespace ToDoListApp.View;

public partial class PaginaPrincipal : ContentPage
{
	public PaginaPrincipal()
	{
		InitializeComponent();
        var viewModel = (PaginaPrincipalViewModel)BindingContext;
        viewModel.Navigation = this.Navigation;
    }
}