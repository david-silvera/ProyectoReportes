<template>
  <div>
    <header class="header">
      <div class="left">
        <span class="user-name">Hola, {{ nombre }} {{ apellido }}</span>
      </div>
      <div class="right">
        <img 
          src="/perfil.png" 
          alt="Perfil" 
          class="icono-perfil" 
          @click="abrirModalPerfil" 
          style="cursor: pointer;"
        />
      </div>
    </header>

    <nav class="nav">
      <button class="nav-button" @click="irInicio">Inicio</button>
      <button class="nav-button" @click="irCrearNoticias">Crear noticia</button>
      <button class="nav-button" @click="irMisNoticias">Mis noticias</button>
      <router-link to="/"><button class="nav-button">Cerrar Sesion</button></router-link>
    </nav>


    <div v-if="mostrarModal" class="modal-overlay" @click.self="cerrarModalPerfil">
      <div class="modal">
        <h3>Perfil de Usuario</h3>

        <div v-if="loading">Cargando datos...</div>

        <div v-else>
          <label>Nombre:</label>
          <input v-model="usuario.nombre" type="text" />

          <label>Apellido:</label>
          <input v-model="usuario.apellido" type="text" />

          <label>Username:</label>
          <input v-model="usuario.username" type="text" />

          <label>Contraseña:</label>
          <input v-model="usuario.contraseña" type="password" />

           <div class="botones-modal">
            <button @click="cerrarModalPerfil">Cerrar</button>
            <button @click="guardarCambios" :disabled="guardando">
              {{ guardando ? 'Guardando...' : 'Guardar' }}
            </button>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>

export default {
  name: 'MenuPrincipal',
  props: {
    nombre: {
      type: String,
      default: ''
    },
    apellido: {
      type: String,
      default: ''
    },
    idusuario: {
      type: Number,
      default: 0
    }
  },
  data() {
    return {
      mostrarModal: false,
      loading: false,
      usuario: {
        nombre: '',
        apellido: '',
        username: '',
        contraseña: ''
      }
    };
  },
  methods: {
    irInicio() {
      this.$router.push({
        name: 'vistaprincipal',
        query: {
          nombre: this.nombre,
          apellido: this.apellido,
          idusuario: this.idusuario
        }
      });
    },
    irMisNoticias() {
      this.$router.push({
        name: 'misnoticias',
        query: {
          nombre: this.nombre,
          apellido: this.apellido,
          idusuario: this.idusuario
        }
      });
    },
    irCrearNoticias() {
      this.$router.push({
        name: 'crearnoticia',
        query: {
          nombre: this.nombre,
          apellido: this.apellido,
          idusuario: this.idusuario
        }
      });
    },

    abrirModalPerfil() {
      this.mostrarModal = true;
      this.cargarDatosUsuario();
    },
    cerrarModalPerfil() {
      this.mostrarModal = false;
    },

    async cargarDatosUsuario() {
      this.loading = true;
      try {
        const response = await this.axios.get(`http://localhost:5272/api/Usuario/${this.idusuario}`);
        this.usuario = {
          nombre: response.data.nombre,
          apellido: response.data.apellido,
          username: response.data.username,
          contraseña: response.data.contraseña || ''
        };
        
      } catch (error) {
        console.error('Error al cargar usuario:', error);
        alert('No se pudieron cargar los datos del usuario.');
      } finally {
        this.loading = false;
      }
    },
     async guardarCambios() {
      this.guardando = true;
      try {
        await this.axios.put(`http://localhost:5272/api/Usuario/${this.idusuario}`, {
          id: this.idusuario,
          nombre: this.usuario.nombre,
          apellido: this.usuario.apellido,
          username: this.usuario.username,
          contraseña: this.usuario.contraseña
        });

        alert('Datos guardados correctamente.');
        this.cerrarModalPerfil();
      } catch (error) {
        console.error('Error al guardar usuario:', error);
        alert('Error al guardar los datos.');
      } finally {
        this.guardando = false;
      }
    }
  }
};
</script>


  <style scoped>

  * {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
    body {
  margin: 0;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  background: linear-gradient(to right, #e3f2fd, #bbdefb);
}

  .header {
  background-color: #0d47a1;
  color: white;
  padding: 15px 30px;
  font-size: 18px;
  font-weight: bold;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

  
  .user-name {
    font-size: 18px;
    font-weight: bold;
  }
  
  .icono-perfil {
    width: 36px;
    height: 36px;
    border-radius: 50%;
    border: 2px solid #ecf0f1;
  }
  
  .nav {
    display: flex;
  justify-content: space-around;
  background-color: #1976d2;
  padding: 10px 0;
  }
  
  .nav-button {
    background: transparent;
  border: none;
  color: white;
  font-size: 16px;
  cursor: pointer;
  padding: 10px 20px;
  border-radius: 20px;
  transition: background 0.3s;
  }
  
  .nav-button:hover {
    background-color: rgba(255, 255, 255, 0.2);
  }

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0,0,0,0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 9999;
}

.modal {
  background-color: white;
  padding: 20px 30px;
  border-radius: 12px;
  max-width: 400px;
  width: 90%;
}

.modal label {
  display: block;
  margin-top: 10px;
  font-weight: bold;
}

.modal input {
  width: 100%;
  padding: 8px;
  margin-top: 4px;
  border-radius: 6px;
  border: 1px solid #ccc;
}

.botones-modal {
  margin-top: 20px;
  display: flex;
  justify-content: flex-end;
}

.botones-modal button {
  background-color: #1e3a8a;
  color: white;
  border: none;
  padding: 8px 14px;
  border-radius: 6px;
  cursor: pointer;
}

.botones-modal button:hover {
  background-color: #16326f;
}
  </style>
  