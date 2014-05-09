using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Desktop.Common;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public abstract partial class CrudForm<TEntity, TCuForm, TService> : Form
        where TEntity : ILogicalRemovableEntity
        where TService : class, ICrudService<TEntity>
        where TCuForm : CuForm<TEntity, TService>, new()
    {
        /// <summary>
        /// Obtiene o establece las entidades de la pagina.
        /// </summary>
        protected TEntity[] Entities { get; private set; }
        /// <summary>
        /// Obtiene la funcion selectora del id de la entidad.
        /// </summary>
        protected abstract Func<TEntity, int> GetId { get; }
        /// <summary>
        /// Obtiene el nombre de la entidada.
        /// </summary>
        protected abstract string EntityName { get; }

        public CrudForm()
        {
            InitializeComponent();
        }

        private void CrudFrom_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (DesignMode)
                    return;

                Text = MessageProviderExtensions.CrudEntity(EntityName);
                ViewLoad();
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                DoSearch();
            });
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                CleanFilters();
            });
        }

        private void dgvEntities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Try.It(() =>
            {
                if (e.RowIndex < 0)
                    return;

                if (dgvEntities.Columns["SelectButton"].Index == e.ColumnIndex)
                {
                    DoUpdate(e.RowIndex);
                }
                if (dgvEntities.Columns["EnableButton"].Index == e.ColumnIndex)
                {
                    DoEnable(e.RowIndex);
                }
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var cuForm = new TCuForm { Text = MessageProviderExtensions.CreateEntity(EntityName) };

                InitCuForm(cuForm);
                if (cuForm.ShowDialog() == DialogResult.OK)
                    DoSearch();
            });
        }

        /// <summary>
        /// Realiza la busqueda y refrezca la grilla.
        /// </summary>
        private void DoSearch()
        {
            var filter = GetFilter();
            var client = Proxy.It<TService>();
            Entities = filter != null ? client.Proxy.List(filter) : client.Proxy.List();

            SetDataSource(Entities);
        }

        /// <summary>
        /// Genera la grilla a partir de las entidades buscadas.
        /// </summary>
        /// <param name="entities">Entidades resultado de la busqueda.</param>
        private void SetDataSource(TEntity[] entities)
        {
            dgvEntities.DataSource = null;
            dgvEntities.Columns.Clear();

            var table = CreateDataTable();

            entities.ForEach(entity => table.Rows.Add(CreateDataRow(table, entity)));

            dgvEntities.DataSource = table;
            dgvEntities.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "SelectButton",
                HeaderText = MessageProvider.Seleccionar
            });

            dgvEntities.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "EnableButton",
                HeaderText = MessageProvider.HabilitarDeshabilitar
            });
        }

        /// <summary>
        /// Retorna la entidad seleccionada en la grilla.
        /// </summary>
        /// <returns>Instancia de la entidad seleccionada.</returns>
        private TEntity GetEntity(int rowIndex)
        {
            var id = (int)dgvEntities.Rows[rowIndex].Cells[0].Value;
            return Entities.First(entity => GetId(entity) == id);
        }

        private void DoUpdate(int rowIndex)
        {
            var entity = GetEntity(rowIndex);
            if (!entity.Activo)
            {
                MsgBox.ShowError(MessageProvider.NoUpdateDisabledEntity);
                return;
            }

            var cuForm = new TCuForm
            {
                Entity = entity,
                Behavior = CuFormBehavior.Update,
                Text = MessageProviderExtensions.UpdateEntity(EntityName)
            };

            InitCuForm(cuForm);
            if (cuForm.ShowDialog() == DialogResult.OK)
                DoSearch();
        }

        private void DoEnable(int rowIndex)
        {
            if (dgvEntities.SelectedRows.Count == 0)
            {
                MsgBox.ShowError(MessageProviderExtensions.EntityRequired(EntityName));
                return;
            }

            var entity = GetEntity(rowIndex);
            if (entity.Activo)
            {
                if (!MsgBox.ShowQuestion(MessageProviderExtensions.ConfirmDisableEntity(EntityName)))
                    return;

                var client = Proxy.It<TService>();
                client.Proxy.Disable(GetId(entity));
                MsgBox.ShowMessage(MessageProviderExtensions.DisableExitoso(EntityName));
            }
            else
            {
                if (!MsgBox.ShowQuestion(MessageProviderExtensions.ConfirmEnableEntity(EntityName)))
                    return;

                var client = Proxy.It<TService>();
                client.Proxy.Enable(GetId(entity));
                MsgBox.ShowMessage(MessageProviderExtensions.EnableExitoso(EntityName));
            }
            DoSearch();
        }

        /// <summary>
        /// Retorna los filtros para la busqueda.
        /// </summary>
        /// <returns>Instancia de la entidad con los datos para filtrar.</returns>
        protected abstract TEntity GetFilter();

        /// <summary>
        /// Retorna la estructura de la tabla de la grilla.
        /// </summary>
        /// <returns>Instancia de la tabla de la grilla.</returns>
        protected abstract DataTable CreateDataTable();

        /// <summary>
        /// Retorna una fila de la grilla a partir de los datos de la entidad.
        /// </summary>
        /// <param name="table">Estructura de la tabla de la grilla.</param>
        /// <param name="entity">Entidad a mostrar en la grilla.</param>
        /// <returns>Instancia de una fila de la grilla.</returns>
        protected abstract DataRow CreateDataRow(DataTable table, TEntity entity);

        /// <summary>
        /// Inicializa el estado del form.
        /// </summary>
        protected virtual void ViewLoad()
        {
        }

        /// <summary>
        /// Limpia los filtros de la grilla.
        /// </summary>
        protected virtual void CleanFilters()
        {
        }

        /// <summary>
        /// Le pasa al CuForm los datos necesarios.
        /// </summary>
        /// <param name="cuForm">CuForm donde se setearan los datos.</param>
        protected virtual void InitCuForm(TCuForm cuForm)
        {
        }
    }
}
