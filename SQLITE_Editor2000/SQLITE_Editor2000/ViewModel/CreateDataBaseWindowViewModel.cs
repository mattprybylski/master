using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SQLITE_Editor2000.Data;
using SQLITE_Editor2000.View;
using SQLITE_Editor2000.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITE_Editor2000.ViewModel
{
    public class CreateDataBaseWindowViewModel : WindowBaseViewModel<int, CreateDataBaseWindow>
    {
        public CreateDataBaseWindowViewModel(IOptions<AppSettings> configuration)
        {
            Window.DataContext = this; 
        }

        public override void ShowWindow()
        {
            Window.Show(); 
        }

        protected override void CloseCommand_Click()
        {
            throw new NotImplementedException();
        }

        protected override Task Delete_Command_Click_Async()
        {
            throw new NotImplementedException();
        }

        protected override void NewCommand_Click()
        {
            throw new NotImplementedException();
        }

        protected override Task Save_Command_Click_Async()
        {
            throw new NotImplementedException();
        }
    }
}
