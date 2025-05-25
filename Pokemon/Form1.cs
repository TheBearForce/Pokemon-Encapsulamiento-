using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pokemon; // asegúrate de usar el mismo namespace



namespace Pokemon
{

    public partial class btnAgregar : Form
    {

        private List<Pokemon> listaPokemones = new List<Pokemon>();
        private List<Pokemon> listaFiltrada = new List<Pokemon>();
        private bool enBusqueda = false;

        public btnAgregar()
        {
            InitializeComponent();
            listaPokemones = Pokedex.Cargar();
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            lstPokemones.Items.Clear();
            foreach (var p in listaPokemones)
                lstPokemones.Items.Add(p.ObtenerResumen());
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtNivel.Clear();
            txtTipoPrimario.Clear();
            txtTipoSecundario.Clear();
            txtCaracteristica.Clear();
            txtHabilidades.Clear();
        }

        private void lstPokemones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPokemones.SelectedIndex < 0) return;

            // Usa la lista correcta según si estás buscando o no
            var fuente = enBusqueda ? listaFiltrada : listaPokemones;

            if (lstPokemones.SelectedIndex >= fuente.Count) return; // Protección extra

            var seleccionado = fuente[lstPokemones.SelectedIndex];
            txtDetalle.Text = seleccionado.ObtenerDetalle();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text.ToLower().Trim();

            listaFiltrada = listaPokemones
                .Where(p => p.Nombre.ToLower().Contains(nombre))
                .ToList();

            enBusqueda = true;

            lstPokemones.Items.Clear();
            foreach (var p in listaFiltrada)
                lstPokemones.Items.Add(p.ObtenerResumen());

            txtDetalle.Clear(); // Limpia detalle al buscar

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string tipo1 = txtTipoPrimario.Text.Trim();
            string tipo2 = txtTipoSecundario.Text.Trim();
            string caracteristica = txtCaracteristica.Text.Trim();
            List<string> habilidades = txtHabilidades.Text.Split(',').Select(h => h.Trim()).ToList();

            if (!int.TryParse(txtNivel.Text, out int nivel) || nivel < 1 || nivel > 200)
            {
                MessageBox.Show("El nivel debe ser un número entre 1 y 200.");
                return;
            }

            //if (listaPokemones.Any(p => p.Nivel == nivel))
            //{
            //    MessageBox.Show($"Ya existe un Pokémon con el nivel {nivel}.");
            //    return;
            //}

            var nuevo = new Pokemon
            {
                Nombre = nombre,
                Nivel = nivel,
                TipoPrimario = tipo1,
                TipoSecundario = tipo2,
                CaracteristicaPrincipal = caracteristica,
                Habilidades = habilidades
            };

            listaPokemones.Add(nuevo);
            Pokedex.Guardar(listaPokemones);
            ActualizarLista();        // <-- importante que esté como arriba
            LimpiarCampos();

            // ✅ Mostrar mensaje de éxito
            MessageBox.Show("¡Pokémon registrado en la 📦 Pokédex!", "Registro exitoso ⚡🐭", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void txtNivel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras, espacio y control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = lstPokemones.SelectedIndex;

            if (index < 0)
            {
                MessageBox.Show("Selecciona un Pokémon para eliminar.");
                return;
            }

            var resultado = MessageBox.Show("¿Estás seguro que deseas eliminar este Pokémon?",
                                             "Confirmar eliminación",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                listaPokemones.RemoveAt(index);
                Pokedex.Guardar(listaPokemones);
                ActualizarLista();
                txtDetalle.Clear(); // Limpia el detalle si había algo mostrado
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            enBusqueda = false;
            listaFiltrada.Clear();
            txtBuscar.Clear();
            txtDetalle.Clear();
            ActualizarLista(); // vuelve a mostrar todos los pokémon
        }
    }
}
