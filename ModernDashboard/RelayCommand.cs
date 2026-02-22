using System;
using System.Windows.Input;

/// <summary>
/// "RelayCommand" PERMITE INJETAR A LÓGICA DO COMANDO POR MEIO DE DELAGATES PASSADOS PARA SEU CONSTRUTOR. ESSE MÉTODO PERMITE QUE AS CLASSES "ViewModel" IMPLEMENTEM COMANDOS DE FORMA CONCISA
/// </summary>

namespace ModernDashboard
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
            canExecute = null;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute= execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// O MÉTODO "CanExecuteChanged" DELEGA A ASSINATURA DO EVENTO PARA O EVENTO "CommandManager.RequerySuggested". ISSO GARANTE QUE A INFRAESTRUTURA DE COMANDOS DO WPF PERGUNTE A TODOS OS OBJETOS "RelayCommand" SE ELES PODEM SER EXECUTADOS SEMPRE QUE OS COMANDOS INTERNOS FOREM SOLICITADOS
        /// </summary>

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
