<template>
  <div>
    <header class="header">
      <div class="left">
        <span class="user-name">Hola, {{ nombre }} {{ apellido }}</span>
      </div>
      <div class="right">
        <img src="/perfil.png" alt="Perfil" class="icono-perfil" />
      </div>
    </header>

    <nav class="nav">
      <button class="nav-button" @click="irInicio">Inicio</button>
      <button class="nav-button">Crear noticia</button>
      <button class="nav-button">Mis noticias</button>
      <button class="nav-button">Otras</button>
    </nav>
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
    }
  },
  methods: {
    irInicio() {
      this.$router.push({
        name: 'vistaprincipal', 
        query: {
          nombre: this.nombre,
          apellido: this.apellido
        }
      });
    }
  }
};
</script>

  <style scoped>
  .header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: #2c3e50;
    color: #ecf0f1;
    padding: 12px 24px;
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
    justify-content: space-evenly;
    background-color: #3498db;
    padding: 12px 0;
  }
  
  .nav-button {
    background: transparent;
    border: none;
    color: #ffffff;
    font-weight: 500;
    font-size: 16px;
    cursor: pointer;
    padding: 8px 16px;
    border-radius: 6px;
    transition: background-color 0.2s ease;
  }
  
  .nav-button:hover {
    background-color: rgba(255, 255, 255, 0.2);
  }
  </style>
  