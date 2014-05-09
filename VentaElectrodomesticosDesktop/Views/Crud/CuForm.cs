using System;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public abstract partial class CuForm<TEntity, TService> : Form
        where TService : class, ICrudService<TEntity>
    {
        /// <summary>
        /// Obtiene o establece el comportamiento del formulario.
        /// </summary>
        public CuFormBehavior Behavior { get; set; }
        /// <summary>
        /// Obtiene o establece la entidad a ser modificada.
        /// </summary>
        public TEntity Entity { get; set; }

        public CuForm()
        {
            InitializeComponent();
        }

        private void CuForm_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                ViewLoad();
                switch (Behavior)
                {
                    case CuFormBehavior.Create:
                        SetCreateBehavior();
                        break;
                    case CuFormBehavior.Update:
                        SetUpdateBehavior();
                        SetEntity(Entity);
                        break;
                }
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<TService>();
                switch (Behavior)
                {
                    case CuFormBehavior.Create:
                        client.Proxy.Add(GetEntity());
                        MsgBox.ShowMessage(MessageProvider.AltaExitosa);
                        break;
                    case CuFormBehavior.Update:
                        client.Proxy.Update(GetEntity());
                        MsgBox.ShowMessage(MessageProvider.ModificacionExitosa);
                        break;
                }
                DialogResult = DialogResult.OK;
                Close();
            });
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Clean();
            });
        }

        /// <summary>
        /// Setea los datos de la entidad en el formulario.
        /// </summary>
        /// <param name="entity">Entidad del formulario.</param>
        protected abstract void SetEntity(TEntity entity);

        /// <summary>
        /// Obtiene la entidad con los datos ingresados en el formulario.
        /// </summary>
        /// <returns>Instancia de la entidad.</returns>
        protected abstract TEntity GetEntity();

        /// <summary>
        /// Limpia los controles del formulario.
        /// </summary>
        protected virtual void Clean() { }

        /// <summary>
        /// Inicializa el formulario en la carga inicial.
        /// </summary>
        protected virtual void ViewLoad() { }

        /// <summary>
        /// Setea el comportamiento para la creacion de una entidad.
        /// </summary>
        protected virtual void SetCreateBehavior() { }

        /// <summary>
        /// Setea el comportamiento para la actualizacion de una entidad.
        /// </summary>
        protected virtual void SetUpdateBehavior() { }
    }
}
